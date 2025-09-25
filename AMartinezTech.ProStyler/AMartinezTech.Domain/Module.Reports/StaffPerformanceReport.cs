using AMartinezTech.Domain.Module.Billing;

namespace AMartinezTech.Domain.Module.Reports;

public class StaffPerformanceReport
{
    public string StaffName { get; private set; }
    public decimal RevenueGenerated { get; private set; }
    public int TotalClientsServed { get; private set; }

    private StaffPerformanceReport(string staffName, decimal revenueGenerated, int totalClientsServed)
    {
        StaffName = staffName;
        RevenueGenerated = revenueGenerated;
        TotalClientsServed = totalClientsServed;
    }

    public static IEnumerable<StaffPerformanceReport> Generate(IEnumerable<InvoiceEntity> invoices)
    {
        return invoices
            .GroupBy(i => i.StaffName)
            .Select(g => new StaffPerformanceReport(
                g.Key,
                g.Sum(x => x.TotalAmount),
                g.Count()
            ));
    }
}
