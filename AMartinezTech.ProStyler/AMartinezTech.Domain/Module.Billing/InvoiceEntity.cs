using AMartinezTech.Domain.Utils.Enums;
using AMartinezTech.Domain.Utils.Exceptions;
using AMartinezTech.Domain.Utils.ValueObjects;

namespace AMartinezTech.Domain.Module.Billing;

public class InvoiceEntity
{
    public Guid Id { get; private set; } = Guid.NewGuid();

    public ValueGuid ClientId { get; private set; }
    public string ClientName { get; private set; }

    public ValueGuid StaffId { get; private set; }
    public string StaffName { get; private set; }

    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public ValueEnum<InvoiceStatus> Status { get; private set; } = ValueEnum<InvoiceStatus>.Create("Pendiente");

    private readonly List<InvoiceItem> _items = [];
    public IReadOnlyCollection<InvoiceItem> Items => _items.AsReadOnly();

    public decimal TotalAmount => _items.Sum(i => i.Total);

 
    private InvoiceEntity(ValueGuid clientId, string clientName, ValueGuid staffId, string staffName)
    {
        ClientId = clientId;
        ClientName = clientName;
        StaffId = staffId;
        StaffName = staffName;
    }
    public static InvoiceEntity Create(Guid clientId, string clientName, Guid staffId, string staffName)
    {
        return new InvoiceEntity(ValueGuid.Create(clientId,"customer"), clientName, ValueGuid.Create(staffId,"staff"), staffName);
    }
    // ✅ Método de dominio para agregar un ítem
    public void AddItem(ValueEnum<ItemType> type, string description, decimal quantity, decimal unitPrice)
    {
        if (quantity <= 0) throw new Exception($"{ErrorMessages.Get(ErrorType.NoNegativeNum)} - quantity");
        if (unitPrice < 0) throw new Exception($"{ErrorMessages.Get(ErrorType.NoNegativeNum)} - unitprice ");


        var item = new InvoiceItem(this.Id, type, description, quantity, unitPrice);
        _items.Add(item);
    }
    // ✅ Método de acceso controlado
    public IReadOnlyCollection<InvoiceItem> GetItems()
        => _items.AsReadOnly(); 


    // ✅ Método para remover ítem
    public void RemoveItem(Guid itemId)
    {
        var item = _items.FirstOrDefault(i => i.Id == itemId);
        if (item != null)
            _items.Remove(item);
    }

    // ✅ Método para marcar factura como pagada
    public void MarkAsPaid() => Status = ValueEnum<InvoiceStatus>.Create("Paga");

    // ✅ Método para cancelar factura
    public void Cancel() => Status = ValueEnum<InvoiceStatus>.Create("Cancelada");

    // 🔒 Clase interna, inaccesible desde fuera
    public class InvoiceItem
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public Guid InvoiceId { get; private set; }
        public ValueEnum<ItemType> Type { get; private set; }
        public string Description { get; private set; }
        public decimal Quantity { get; private set; }
        public decimal UnitPrice { get; private set; }
        public decimal Total => Quantity * UnitPrice;

        internal InvoiceItem(Guid invoiceId, ValueEnum<ItemType> type, string description, decimal quantity, decimal unitPrice)
        {
            InvoiceId = invoiceId;
            Type = type;
            Description = description;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }
    }
}

