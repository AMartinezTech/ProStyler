using AMartinezTech.Application.Module.Billing.Interfaces;
using AMartinezTech.Application.Utils;
using AMartinezTech.Domain.Module.Billing;

namespace AMartinezTech.Application.Module.Billing.UseCases.Write;

public class InvoicePersistence (IInvoiceWriteRepository repository)
{
    private readonly IInvoiceWriteRepository _repository = repository;

    public async Task<Guid> ExecuteAsync(InvoiceDto dto)
    {
        Guid _id = GeneratesId.Make(dto.Id);

        var entity = InvoiceEntity.Create(_id, dto.ClientId, dto.ClientName, dto.StaffId, dto.StaffName);

        foreach (var item in dto.Items) 
        {
            entity.AddItem(item.Type, item.Description, item.Quantity, item.UnitPrice);
        }

        if (dto.Id == Guid.Empty) { await _repository.CreateAsync(entity); } else { await _repository.UpdateAsync(entity); }

        return _id;
    }
}
