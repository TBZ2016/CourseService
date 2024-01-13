using Application;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using Presistence;
using System.Reflection;
using System.Security.Claims;
using System.Text.Json.Serialization;


namespace KawaAssignment
{
    public class Program
    {
        public static IConfiguration Configuration { get; set; }

        private static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            // Configuration setup
            Configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true) // Load Development settings
                .AddEnvironmentVariables()
                .Build();


            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {

                //options.Authority = "http://localhost:8080/auth/realms/master";
                options.Authority = "http://localhost:8080/auth/realms/assignment";
                options.Audience = "account";
                options.RequireHttpsMetadata = false;

                //options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                //{
                //    ValidateIssuer = false,
                //    ValidateAudience = false,
                //    ValidateLifetime = false,
                //    ValidateIssuerSigningKey = false,
                //    ValidIssuer = "http://localhost:8080/auth/realms/assignment",
                //    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("account"))
                //};

                //options.Events = new JwtBearerEvents()
                //{
                //    OnTokenValidated = c =>
                //    {
                //        Console.WriteLine("User successfully authenticated");
                //        return Task.CompletedTask;
                //    },
                //    OnAuthenticationFailed = c =>
                //    {
                //        c.NoResult();
                //        c.Response.StatusCode = 500;
                //        c.Response.ContentType = "text/plain";

                //        return c.Response.WriteAsync("An error occured processing your authentication.");
                //    }
                // };
            });

            builder.Services.AddTransient<IClaimsTransformation, ClaimsTransformer>();

            // ** This is to configure Swagger to generate the API documentation **//
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            // Add services to the container.
            builder.Services.AddControllers()
                .AddJsonOptions(options =>
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer()
                .AddSwaggerGen()
                .AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies())
                .AddPresistenceServices(Configuration)
                .AddApplicationServices(Configuration);

            var app = builder.Build();

            app.UseSwagger();

            app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            await app.RunAsync();

        }
    }

   
    }

    public class ClaimsTransformer : IClaimsTransformation
    {
        public Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            ClaimsIdentity claimsIdentity = (ClaimsIdentity)principal.Identity;

            // flatten resource_access because Microsoft identity model doesn't support nested claims
            // by map it to Microsoft identity model, because automatic JWT bearer token mapping already processed here
            if (claimsIdentity.IsAuthenticated && claimsIdentity.HasClaim((claim) => claim.Type == "resource_access"))
            {
                var userRole = claimsIdentity.FindFirst((claim) => claim.Type == "resource_access");

                var content = Newtonsoft.Json.Linq.JObject.Parse(userRole.Value);

                foreach (var role in content["account"]["roles"])
                {
                    claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, role.ToString()));
                }
            }

            return Task.FromResult(principal);
        }
    }

