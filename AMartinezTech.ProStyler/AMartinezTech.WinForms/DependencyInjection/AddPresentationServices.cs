using AMartinezTech.WinForms.Utils.Factories;
using Microsoft.Extensions.DependencyInjection;

namespace AMartinezTech.WinForms.DependencyInjection;

public class AddPresentationServices
{
    public static void Configure(IServiceCollection services)
    {
        services.AddTransient<IFormFactory, FormFactory>();
        services.AddTransient<FrmMainView>();

        // Appointment
        DIAppointmentServices.AddServices(services);

        // Dashboard Adminitration
        DIDashboardAdminServices.AddServices(services);
        
        // Setting
        DISettingServices.AddServices(services);
        
        // User
        DIUserServices.AddServices(services);

    }
}
