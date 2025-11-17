using HR.LeaveManagement.Infrastructure;
using HR.LeaveManagement.Persistence;
using HR.LeaveManagement.Application;
using HR.LeaveManagement.Api.Middleware;
using HR.LeaveManagement.Identity;

namespace HR.LeaveManagement.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddApplicationServices(builder.Configuration);
            builder.Services.AddPersistenceServices(builder.Configuration);
            builder.Services.ConfigureInfrastructureServices(builder.Configuration);
            builder.Services.ConfigureIdentityServices(builder.Configuration);

            builder.Services.AddControllers();
            
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("all", builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });
            builder.Services.AddHttpContextAccessor();

            // Enhanced Swagger Configuration for .NET 9
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddOpenApi();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "HR Leave Management API",
                    Version = "v1.0",
                    Description = "A comprehensive API for managing employee",
                });

            });

            var app = builder.Build();

            app.UseMiddleware<ExceptionMiddleware>();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi(); // Maps OpenAPI specification endpoint
                
                // Configure Swagger UI
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/openapi/v1.json", "HR Leave Management API v1");
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "HR Leave Management API v1 (Legacy)");
                    options.RoutePrefix = "swagger";
                    options.DocumentTitle = "HR Leave Management API Documentation";
                    options.DisplayRequestDuration();
                    options.EnableTryItOutByDefault();
                    options.DefaultModelExpandDepth(2);
                    options.DefaultModelRendering(Swashbuckle.AspNetCore.SwaggerUI.ModelRendering.Example);
                });
            }

            app.UseHttpsRedirection();
            app.UseCors("all");
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
           
            app.Run();
        }
    }
}
