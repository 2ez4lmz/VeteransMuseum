using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VeteransMuseum.Application.Abstractions.Clock;
using VeteransMuseum.Infrastructure.Clock;

namespace VeteransMuseum.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddTransient<IDateTimeProvider, DateTimeProvider>();

        return services;
    }
}