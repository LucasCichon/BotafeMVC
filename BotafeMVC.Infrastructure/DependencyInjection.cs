using BotafeMVC.Domain.Interfaces;
using BotafeMVC.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BotafeMVC.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IRepository, Repository>();
            services.AddTransient<IEventRepository, EventRepository>();
            return services;
        }
    }
}
