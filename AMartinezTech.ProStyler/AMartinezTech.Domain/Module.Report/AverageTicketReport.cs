using AMartinezTech.Domain.Module.Billing;

namespace AMartinezTech.Domain.Module.Report;

public class AverageTicketReport
{
    public decimal AverageTicket { get; private set; }
    public int TotalInvoices { get; private set; }

    private AverageTicketReport(decimal averageTicket, int totalInvoices)
    {
        AverageTicket = averageTicket;
        TotalInvoices = totalInvoices;
    }

    public static AverageTicketReport Generate(IEnumerable<InvoiceEntity> invoices)
    {
        var totalInvoices = invoices.Count();
        if (totalInvoices == 0)
            return new AverageTicketReport(0, 0);

        var average = invoices.Average(i => i.TotalAmount);
        return new AverageTicketReport(average, totalInvoices);
    }
}
