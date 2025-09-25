namespace AMartinezTech.Application.Module.Reports.DTOs;

public class ProductUsageReportDto
{
    public string ProductName { get; set; } = string.Empty;
    public int TimesSold { get; set; }
    public decimal TotalRevenue { get; set; }
}
