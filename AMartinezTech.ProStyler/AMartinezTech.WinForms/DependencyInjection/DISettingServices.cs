using AMartinezTech.Application.Module.Administration.Settings.UseCases;
using Microsoft.Extensions.DependencyInjection;

namespace AMartinezTech.WinForms.DependencyInjection
{
    public class DISettingServices
    {
        public static void AddServices(IServiceCollection services)
        {
           
            services.AddTransient<SettingPagination>();
            services.AddTransient<SettingPersistence>();
        }
    }
}
