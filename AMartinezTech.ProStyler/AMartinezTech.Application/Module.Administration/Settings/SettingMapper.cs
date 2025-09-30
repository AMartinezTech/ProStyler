using AMartinezTech.Domain.Module.Administration;

namespace AMartinezTech.Application.Module.Administration.Settings;

internal class SettingMapper
{
    internal static SettingDto ToDto(SettingEntity entity)
    {
        return new SettingDto
        {
            Id = entity.Id,
            CompanyName = entity.CompanyName,
            Line1 = entity.Line1,
            Line2 = entity.Line2,
            Line3 = entity.Line3,
            InvoiceNote = entity.InvoiceNote,
            InvoicePrintName = entity.InvoicePrintName,
            InvoicePrintType = entity.InvoicePrintType.ToString(),
        };
    }

    
}
