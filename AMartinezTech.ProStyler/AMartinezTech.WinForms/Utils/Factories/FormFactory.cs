using Microsoft.Extensions.DependencyInjection;

namespace AMartinezTech.WinForms.Utils.Factories;

public class FormFactory(IServiceProvider serviceProvider) : IFormFactory
{
    private readonly IServiceProvider _serviceProvider = serviceProvider;

    public T CreateFormFactory<T>() where T : Form
    {
        return _serviceProvider.GetRequiredService<T>();    
    }
}
