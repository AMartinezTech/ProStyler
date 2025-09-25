namespace AMartinezTech.Application.Module.Reports.DTOs;

public class InvoiceStatusReportDto
{
    public string Status { get;  set; } = string.Empty;
    public int Count { get;  set; }
    public decimal TotalAmount { get;  set; }
}
