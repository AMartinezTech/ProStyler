using AMartinezTech.Domain.Module.Billing;

namespace AMartinezTech.Application.Module.Billing;

internal class InvoiceMapper
{
    internal static InvoiceDto ToDto(InvoiceEntity entity)
    {
        return new InvoiceDto
        {
            Id = entity.Id,
            ClientId = entity.ClientId.Value,
            ClientName = entity.ClientName,
            StaffId = entity.StaffId.Value,
            StaffName = entity.StaffName,
            CreatedAt = entity.CreatedAt,
            Items = entity.Items.Select(e => new InvoiceItemDto
            {
                Id= e.Id,
                InvoiceId = e.InvoiceId,
                Type = e.Type.ToString(),
                Description = e.Description,
                Quantity = e.Quantity,
                UnitPrice = e.UnitPrice,
            }).ToList(),
        };
    }

    internal static List<InvoiceDto> ToDtoList(IEnumerable<InvoiceEntity> entities)
    {
        return [.. entities.Select(ToDto).ToList()];
    }
}
