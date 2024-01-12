using Application;
using Infrastructure;
using Presistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using System.Text.Json.Serialization;
using Microsoft.OpenApi.Models;
using System.Reflection;

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
                .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true)
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
                //options.Audience = "assignment-cleint";
                options.Audience = "account";
                options.RequireHttpsMetadata = false; 

               
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
                .AddInfrastructureServices(Configuration)
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

    public static class DependencyInjectionsHelpers
    {
        public static void AddServicesNeededForController(this IServiceCollection services, IConfiguration configuration)
        {
        }

    }

    public class ClaimsTransformer : IClaimsTransformation
    {
        public Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            ClaimsIdentity claimsIdentity = (ClaimsIdentity)principal.Identity;

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

}
