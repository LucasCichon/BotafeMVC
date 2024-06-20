using BotafeMVC.Common;
using BotafeMVC.Domain.Interfaces;
using BotafeMVC.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;

namespace BotafeMVC.Web.Authorization
{
    public static class AuthorizationExtensions
    {
        public static IServiceCollection AddPolicies(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy(ServiceConstants.Policies.CanAddEvent, policy =>
                {
                    policy.RequireClaim(ServiceConstants.Claims.AddNewEvent);
                });
                options.AddPolicy(ServiceConstants.Policies.CanViewEvents, policy =>
                {
                    policy.RequireClaim(ServiceConstants.Claims.ViewEvents);
                });
                options.AddPolicy(ServiceConstants.Policies.CanEditEvent, policy =>
                {
                    policy.RequireClaim(ServiceConstants.Claims.EditEvent);
                });
                options.AddPolicy(ServiceConstants.Policies.CanDeleteEvent, policy =>
                {
                    policy.RequireClaim(ServiceConstants.Claims.DeleteEvent);
                });
            });
            return services;
        }

        public static IServiceCollection SetRegisterConfiguration(this IServiceCollection services)
        {
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredUniqueChars = 1;

                options.SignIn.RequireConfirmedEmail = true;
                options.User.RequireUniqueEmail = true;
            });

            return services;
        }
    }
}
