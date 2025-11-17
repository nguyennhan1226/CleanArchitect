using HR.LeaveManagement.Application.Contracts.Email;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;



namespace HR.LeaveManagement.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(cfg => {
                // nếu có cấu hình thêm
            }, typeof(ApplicationServiceRegistration).Assembly);

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
           
            return services;
        }
    }
}


