using Domain.Interfaces;
using Infrastructure.Context;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IConfigurationRoot Configuration { get; } 
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {

            services.AddScoped<ITodoRepository, TodoRepository>();
            services.AddDbContext<TodoContext>(options => options.UseSqlServer(Configuration.GetConnectionString("default")));

            return services;

        }
    }
}
