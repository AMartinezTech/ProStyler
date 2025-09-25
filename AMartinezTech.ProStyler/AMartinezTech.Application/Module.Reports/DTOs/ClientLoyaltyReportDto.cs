namespace AMartinezTech.Application.Module.Reports.DTOs;

public class ClientLoyaltyReportDto
{
    public string ClientName { get; set; } = string.Empty;
    public int TotalVisits { get; set; }
    public decimal TotalSpent { get; set; }
}
