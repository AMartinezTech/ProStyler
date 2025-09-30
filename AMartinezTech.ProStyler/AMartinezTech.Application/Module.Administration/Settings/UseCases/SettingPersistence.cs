using AMartinezTech.Application.Module.Administration.Settings.Interfaces;
using AMartinezTech.Application.Utils;
using AMartinezTech.Domain.Module.Administration;

namespace AMartinezTech.Application.Module.Administration.Settings.UseCases;

public class SettingPersistence(ISettingWriteRepository repository)
{
    private readonly ISettingWriteRepository _repository = repository;

    public async Task<Guid> ExecuteAsync(SettingDto dto)
    {
        Guid _id = GeneratesId.Make(dto.Id);
        var entity = SettingEntity.Create(
             _id,
             dto.CompanyName,
             dto.Line1,
             dto.Line2,
             dto.Line3,
             dto.InvoiceNote,
             dto.InvoicePrintName,
             dto.InvoicePrintType
            );

        if (dto.Id == Guid.Empty) { await _repository.CreateAsync(entity); } else { await _repository.UpdateAsync(entity); }

        return _id;
    }
}
