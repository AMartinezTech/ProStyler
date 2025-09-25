namespace AMartinezTech.Application.Module.Reports.DTOs;

public class ServiceUsageReportDto
{
    public string ServiceName { get; set; } = string.Empty;
    public int TimesUsed { get; set; }
    public decimal TotalRevenue { get; set; }
}
