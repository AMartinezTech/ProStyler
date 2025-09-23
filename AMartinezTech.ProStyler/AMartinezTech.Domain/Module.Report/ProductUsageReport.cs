using AMartinezTech.Domain.Module.Billing;
using AMartinezTech.Domain.Utils.Enums;

namespace AMartinezTech.Domain.Module.Report;

public class ProductUsageReport
{
    public string ProductName { get; private set; }
    public int TimesSold { get; private set; }
    public decimal TotalRevenue { get; private set; }

    private ProductUsageReport(string productName, int timesSold, decimal totalRevenue)
    {
        ProductName = productName;
        TimesSold = timesSold;
        TotalRevenue = totalRevenue;
    }

    public static IEnumerable<ProductUsageReport> Generate(IEnumerable<InvoiceEntity> invoices)
    {
        return invoices
            .SelectMany(i => i.GetItems())
            .Where(item => item.Type.Value == ItemType.Product.ToString())
            .GroupBy(p => p.Description)
            .Select(g => new ProductUsageReport(
                g.Key,
                g.Count(),
                g.Sum(x => x.Total)
            ));
    }
}
