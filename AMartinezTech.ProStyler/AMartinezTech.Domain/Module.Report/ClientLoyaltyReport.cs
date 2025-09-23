using AMartinezTech.Domain.Module.Billing;

namespace AMartinezTech.Domain.Module.Report;

public class ClientLoyaltyReport
{
    public string ClientName { get; private set; }
    public int TotalVisits { get; private set; }
    public decimal TotalSpent { get; private set; }

    private ClientLoyaltyReport(string clientName, int totalVisits, decimal totalSpent)
    {
        ClientName = clientName;
        TotalVisits = totalVisits;
        TotalSpent = totalSpent;
    }

    public static IEnumerable<ClientLoyaltyReport> Generate(IEnumerable<InvoiceEntity> invoices)
    {
        return invoices
            .GroupBy(i => i.ClientName)
            .Select(g => new ClientLoyaltyReport(
                g.Key,
                g.Count(),
                g.Sum(x => x.TotalAmount)
            ))
            .OrderByDescending(r => r.TotalSpent);
    }
}
