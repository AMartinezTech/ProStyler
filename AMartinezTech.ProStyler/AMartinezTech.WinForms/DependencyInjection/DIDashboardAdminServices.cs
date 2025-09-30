using AMartinezTech.WinForms.Module.Administration;
using AMartinezTech.WinForms.Module.Administration.Company;
using Microsoft.Extensions.DependencyInjection;

namespace AMartinezTech.WinForms.DependencyInjection;

public class DIDashboardAdminServices
{
    public static void AddServices(IServiceCollection services)
    {
        
        services.AddTransient<FrmAdminDashboardView>();
        services.AddTransient<CompanyController>();
    }
}
