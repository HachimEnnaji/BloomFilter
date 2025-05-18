using BloomFilter.Application.Interfaces;
using BloomFilter.Application.Services;
using BloomFilter.Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BloomFilter.Application.Configurations
{
    public static class RegistrationService
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            services.AddSingleton(typeof(ICacheService<>), typeof(InMemoryCacheService<>));


            services.AddScoped<MemberService>();

            services.AddScoped<IMemberService>(provider =>
            {
                var baseService = provider.GetRequiredService<MemberService>();
                var cacheService = provider.GetRequiredService<ICacheService<MemberDto>>();

                return new MemberCacheService(baseService, cacheService);

            });


            return services;
        }
    }
}
