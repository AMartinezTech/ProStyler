using AMartinezTech.Domain.Module.Billing;

namespace AMartinezTech.Domain.Module.Report;

public class InvoiceStatusReport
{
    public string Status { get; private set; }
    public int Count { get; private set; }
    public decimal TotalAmount { get; private set; }

    private InvoiceStatusReport(string status, int count, decimal totalAmount)
    {
        Status = status;
        Count = count;
        TotalAmount = totalAmount;
    }

    public static IEnumerable<InvoiceStatusReport> Generate(IEnumerable<InvoiceEntity> invoices)
    {
        return invoices
            .GroupBy(i => i.Status.Type.ToString())
            .Select(g => new InvoiceStatusReport(
                g.Key,
                g.Count(),
                g.Sum(x => x.TotalAmount)
            ));
    }
}
