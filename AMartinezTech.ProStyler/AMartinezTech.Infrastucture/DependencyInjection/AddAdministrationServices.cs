using AMartinezTech.Application.Module.Administration.Settings.Interfaces;
using AMartinezTech.Application.Module.Administration.Users.Interfaces;
using AMartinezTech.Infrastucture.SqlServer.Module.Administration.Settings;
using AMartinezTech.Infrastucture.SqlServer.Module.Administration.Users;
using Microsoft.Extensions.DependencyInjection;

namespace AMartinezTech.Infrastucture.DependencyInjection;

public static class DIAdministrationServices
{
    public static IServiceCollection AddAdministrationModule(this IServiceCollection services, string connectionString)
    {
        
        // Users
        services.AddScoped<IUserReadRepository>(sp => new UserReadRepository(connectionString));
        services.AddScoped<IUserWriteRepository>(sp => new UserWriteRepository(connectionString));

        // Settings
        services.AddScoped<ISettingReadRepository>(sp => new SettingReadRepository(connectionString));
        services.AddScoped<ISettingWriteRepository>(sp => new SettingWriteRepository(connectionString));
        
        return services;
    }
}
