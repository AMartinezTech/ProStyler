using AMartinezTech.WinForms.Module.Appointments.Views;
using Microsoft.Extensions.DependencyInjection;

namespace AMartinezTech.WinForms.DependencyInjection;

public class DIAppointmentServices
{
    public static void AddServices(IServiceCollection services)
    {
        
        services.AddTransient<FrmListAppointmentView>();
    }
}
