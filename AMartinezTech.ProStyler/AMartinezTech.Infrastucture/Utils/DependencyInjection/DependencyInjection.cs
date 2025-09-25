using Microsoft.Extensions.DependencyInjection;

namespace AMartinezTech.Infrastucture.Utils.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
    {

        return services;
    }
}
