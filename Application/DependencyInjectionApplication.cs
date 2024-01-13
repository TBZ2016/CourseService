using Application.BusinessLogic;
using Application.Interfaces.IBusinessLogic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjectionApplication
    {

        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<ICourseService, CourseService>();
            services.AddTransient<IModuleService, ModuleService>();
            services.AddTransient<IGroupService, GroupService>();

            return services;
        }
    }
}