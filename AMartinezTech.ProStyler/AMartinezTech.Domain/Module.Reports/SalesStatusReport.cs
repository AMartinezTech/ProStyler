using AMartinezTech.Domain.Module.Billing;

namespace AMartinezTech.Domain.Module.Reports;

public class SalesStatusReport
{
    public string Status { get; private set; }
    public int Count { get; private set; }
    public decimal TotalAmount { get; private set; }

    private SalesStatusReport(string status, int count, decimal totalAmount)
    {
        Status = status;
        Count = count;
        TotalAmount = totalAmount;
    }

    public static IEnumerable<SalesStatusReport> Generate(IEnumerable<InvoiceEntity> invoices)
    {
        return invoices
            .GroupBy(i => i.Status.Type.ToString())
            .Select(g => new SalesStatusReport(
                g.Key,
                g.Count(),
                g.Sum(x => x.TotalAmount)
            ));
    }
}
