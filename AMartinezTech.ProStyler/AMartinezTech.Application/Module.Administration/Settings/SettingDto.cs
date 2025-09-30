namespace AMartinezTech.Application.Module.Administration.Settings;

public class SettingDto
{
    public Guid Id { get; set; }
    public string CompanyName { get; set; } = string.Empty;
    public string Line1 { get; set; } = string.Empty;
    public string Line2 { get; set; } = string.Empty;
    public string Line3 { get; set; } = string.Empty;
    public string InvoiceNote { get; set; } = string.Empty;
    public string InvoicePrintName { get; set; } = string.Empty;
    public string InvoicePrintType { get; set; } = string.Empty;
}
