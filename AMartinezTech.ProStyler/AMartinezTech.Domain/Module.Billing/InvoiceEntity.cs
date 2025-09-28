using AMartinezTech.Domain.Utils.Enums;
using AMartinezTech.Domain.Utils.Exceptions;
using AMartinezTech.Domain.Utils.ValueObjects;

namespace AMartinezTech.Domain.Module.Billing;

public class InvoiceEntity
{
    public Guid Id { get; private set; }
    public ValueGuid ClientId { get; private set; }
    public string ClientName { get; private set; }
    public ValueGuid StaffId { get; private set; }
    public string StaffName { get; private set; }
    public DateTime CreatedAt { get; private set; } 
    public ValueEnum<InvoiceStatus> Status { get; private set; } = ValueEnum<InvoiceStatus>.Create("Pendiente");
    private readonly List<InvoiceDetailEntity> _items = [];
    public IReadOnlyCollection<InvoiceDetailEntity> Items => _items.AsReadOnly();

    public decimal TotalAmount => _items.Sum(i => i.Total);


    private InvoiceEntity(Guid id, ValueGuid clientId, string clientName, ValueGuid staffId, string staffName, DateTime createdAt, ValueEnum<InvoiceStatus> status)
    {
        Id = id;
        ClientId = clientId;
        ClientName = clientName;
        StaffId = staffId;
        StaffName = staffName;
        CreatedAt = createdAt;
        Status = status;
    }
    public static InvoiceEntity Create(Guid id, Guid clientId, string clientName, Guid staffId, string staffName, DateTime createdAt, string status)
    {
        return new InvoiceEntity(id, ValueGuid.Create(clientId, "customer"), clientName, ValueGuid.Create(staffId, "staff"), staffName, createdAt, ValueEnum<InvoiceStatus>.Create(status));
    }
    // ✅ Método de dominio para agregar un ítem
    public void AddDetail(InvoiceDetailEntity detail)
    {
        if (detail.Quantity <= 0) throw new Exception($"{ErrorMessages.Get(ErrorType.NoNegativeNum)} - quantity");
        if (detail.UnitPrice < 0) throw new Exception($"{ErrorMessages.Get(ErrorType.NoNegativeNum)} - unitprice ");


        
        _items.Add(detail);
    }
    // ✅ Método de acceso controlado
    public IReadOnlyCollection<InvoiceDetailEntity> GetItems()
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
 
}

