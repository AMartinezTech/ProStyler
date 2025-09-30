using Microsoft.Extensions.DependencyInjection;

namespace AMartinezTech.Infrastucture.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, string connectionString)
    {
        services.AddAdministrationModule(connectionString);
        return services;
    }
}
