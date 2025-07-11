using BusinessLogic.IServices;
using BusinessLogic.Services;
using DataAccess.Data;
using DataAccess.IRepositories;
using DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.SemanticKernel;

namespace ChatbotAPI.Extensions
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Register repositories
            services.AddScoped<IUOW, UOW>();
            services.AddScoped<IChatService, ChatService>();

            // Register AutoMapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // Add configuration for DbContext
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            // Register DbContext with SQL Server
            services.AddDbContext<ProductBEDbContext>(options =>
                options.UseSqlServer(connectionString));

            // Configure other settings
            services.Configure<RouteOptions>(options =>
            {
                options.LowercaseUrls = true;
            });

            services.AddSingleton<Kernel>(AddKernal());
            return services;
        }

        public static Kernel AddKernal()
        {
            IKernelBuilder kernelBuilder = Kernel.CreateBuilder();
            kernelBuilder.AddOllamaChatCompletion("qwen3:0.6b", new Uri("http://localhost:11434"));
            kernelBuilder.Services.AddSingleton<HttpClient>();
            Kernel kernel = kernelBuilder.Build();
            return kernel;

        }

    }
}
