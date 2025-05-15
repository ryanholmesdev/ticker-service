using TickerService.Domain.Services;

namespace TickerService.Api.Extensions;

public static class ServiceRegistration
{
    public static IServiceCollection AddDomainServices(this IServiceCollection services)
    {
        services.AddScoped<ITickerService, Domain.Services.TickerService>();
        return services;
    }
}