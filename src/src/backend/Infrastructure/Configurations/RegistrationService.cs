using BloomFilter.Core.Interfaces;
using BloomFilter.Infrastructure.Data;
using BloomFilter.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BloomFilter.Infrastructure.Configurations;

public static class RegistrationService
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IMemberRepository, MemberRepository>();

        return services;
    }
}
