namespace AMartinezTech.Application.Module.Billing;

public class InvoiceItemDto
{
    public Guid Id { get;  set; } 
    public Guid InvoiceId { get;  set; }
    public string Type { get;  set; } = string.Empty;
    public string Description { get;  set; } = string.Empty;
    public decimal Quantity { get;  set; }
    public decimal UnitPrice { get;  set; }
    public decimal Total => Quantity * UnitPrice;
}
