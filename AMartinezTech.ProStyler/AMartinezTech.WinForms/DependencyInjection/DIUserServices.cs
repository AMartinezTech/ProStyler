using AMartinezTech.Application.Module.Administration.Users.UseCases.Read;
using AMartinezTech.Application.Module.Administration.Users.UseCases.Write;
using AMartinezTech.WinForms.Module.Administration;
using AMartinezTech.WinForms.Module.Administration.Users;
using AMartinezTech.WinForms.Module.Administration.Users.Login;
using Microsoft.Extensions.DependencyInjection;

namespace AMartinezTech.WinForms.DependencyInjection;

public  class DIUserServices
{
    public static void AddServices(IServiceCollection services)
    {
        services.AddTransient<FrmLogin>();
        services.AddTransient<UserLoginController>();
        services.AddTransient<UserLogin>();
        services.AddTransient<FrmUserView>();
        services.AddTransient<UserController>();
        services.AddTransient<UserPersistence>();
        services.AddTransient<UserGetById>();
        services.AddTransient<UserFilter>();
    }
}
