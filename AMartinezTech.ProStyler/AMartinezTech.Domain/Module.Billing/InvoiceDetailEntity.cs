using AMartinezTech.Domain.Utils.Enums;
using AMartinezTech.Domain.Utils.ValueObjects;

namespace AMartinezTech.Domain.Module.Billing;

public class InvoiceDetailEntity
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public Guid InvoiceId { get; private set; }
    public ValueEnum<ItemType> Type { get; private set; }
    public string Description { get; private set; }
    public decimal Quantity { get; private set; }
    public decimal UnitPrice { get; private set; }
    public decimal Total => Quantity * UnitPrice;

    private InvoiceDetailEntity(Guid invoiceId, ValueEnum<ItemType> type, string description, decimal quantity, decimal unitPrice)
    {
        InvoiceId = invoiceId;
        Type = type;
        Description = description;
        Quantity = quantity;
        UnitPrice = unitPrice;
    }

    public static InvoiceDetailEntity Create(Guid invoiceId, string type, string description, decimal quantity, decimal unitPrice)
    {
        return new InvoiceDetailEntity(invoiceId, ValueEnum<ItemType>.Create(type), description, quantity, unitPrice);
    }
     
}
