using AMartinezTech.Domain.Module.Billing;
using AMartinezTech.Domain.Utils.Enums;

namespace AMartinezTech.Domain.Module.Reports;

public class ServiceUsageReport
{
    public string ServiceName { get; private set; }
    public int TimesUsed { get; private set; }
    public decimal TotalRevenue { get; private set; }

    private ServiceUsageReport(string serviceName, int timesUsed, decimal totalRevenue)
    {
        ServiceName = serviceName;
        TimesUsed = timesUsed;
        TotalRevenue = totalRevenue;
    }

    public static IEnumerable<ServiceUsageReport> Generate(IEnumerable<InvoiceEntity> invoices)
    {
        return invoices
            .SelectMany(i => i.GetItems()) // Método expuesto desde InvoiceEntity
            .Where(item => item.Type.Type == ItemType.Servicio)
            .GroupBy(s => s.Description)
            .Select(g => new ServiceUsageReport(
                g.Key,
                g.Count(),
                g.Sum(x => x.Total)
            ));
    }
}
