using BloomFilter.Application.Interfaces;
using BloomFilter.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BloomFilter.Application.Configurations
{
    public static class RegistrationService
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            services.AddScoped<IMemberService, MemberService>();

            return services;
        }
    }
}
