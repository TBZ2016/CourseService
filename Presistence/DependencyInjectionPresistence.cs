using Application.Interfaces.IPresistence;
using Domain.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Presistence.BaseRepositories;

namespace Presistence
{
    public static class DependencyInjectionPresistence
    {
        //public static IServiceCollection AddPresistenceServices(this IServiceCollection services, IConfiguration configuration)
        //{
        //    // Get MongoDB connection string from configuration
        //    var mongoDbConnectionString = configuration.GetSection("MongoDBConnection").GetValue<string>("MongoDBConnectionString");
        //    var mongoDbDatabaseName = configuration.GetSection("MongoDBConnection").GetValue<string>("DatabaseName");

        //    // Configure MongoDB
        //    var mongoClient = new MongoClient(mongoDbConnectionString);
        //    var mongoDatabase = mongoClient.GetDatabase(mongoDbDatabaseName);

        //    // Configure DbContext for SQL Server (if needed)
        //    var sqlServerConnectionString = configuration.GetConnectionString("DBConnectionString");
        //    services.AddDbContext<BaseDBContext>(options =>
        //        options.UseSqlServer(sqlServerConnectionString));

        //    // Register MongoDB client and database
        //    services.AddSingleton<IMongoClient>(mongoClient);
        //    services.AddSingleton<IMongoDatabase>(mongoDatabase);

        //    // Add repositories
        //    services.AddScoped
        //    services.AddScoped();
        //    services.AddScoped

        //    // Add base repository
        //    services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

        //    return services;
        //}

        public static IServiceCollection AddPresistenceServices(this IServiceCollection services, IConfiguration configuration)
        {


            services.AddSingleton<BaseDBContext>();
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddTransient<ICourseRepository, CourseRepository>();
            services.AddTransient<IModuleRepository, ModuleRepository>();
            services.AddTransient<IGroupRepository, GroupRepository>();

            return services;
        }
    }
}
