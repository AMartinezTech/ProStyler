namespace AMartinezTech.Application.Module.Reports.DTOs;

public class StaffPerformanceReportDto
{
    public string StaffName { get; set; } = string.Empty;
    public decimal RevenueGenerated { get; set; }
    public int TotalClientsServed { get; set; }
}
