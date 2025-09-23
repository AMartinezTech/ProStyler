using AMartinezTech.Domain.Module.Billing;

namespace AMartinezTech.Domain.Module.Report;

public class SalesReport
{
    public DateTime Date { get; private set; }
    public decimal TotalSales { get; private set; }
    public int TotalInvoices { get; private set; }

    private SalesReport(DateTime date, decimal totalSales, int totalInvoices)
    {
        Date = date;
        TotalSales = totalSales;
        TotalInvoices = totalInvoices;
    }

    public static SalesReport Create(DateTime date, IEnumerable<InvoiceEntity> invoices)
    {
        var filtered = invoices.Where(i => i.CreatedAt.Date == date.Date);
        return new SalesReport(
            date,
            filtered.Sum(i => i.TotalAmount),
            filtered.Count()
        );
    }
}

