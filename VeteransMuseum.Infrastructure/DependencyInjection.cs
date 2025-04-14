using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VeteransMuseum.Application.Abstractions.Clock;
using VeteransMuseum.Application.Abstractions.Data;
using VeteransMuseum.Infrastructure.Clock;
using VeteransMuseum.Infrastructure.Data;

namespace VeteransMuseum.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddTransient<IDateTimeProvider, DateTimeProvider>();
        
        var connectionString =
            configuration.GetConnectionString("Database") ??
            throw new ArgumentNullException(nameof(configuration));
        
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql(connectionString).UseSnakeCaseNamingConvention();
        });
        
        services.AddSingleton<ISqlConnectionFactory>(_ =>
            new SqlConnectionFactory(connectionString));

        return services;
    }
}