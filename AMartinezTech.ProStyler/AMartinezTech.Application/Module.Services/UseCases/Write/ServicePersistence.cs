using AMartinezTech.Application.Module.Services.Interfaces;
using AMartinezTech.Application.Utils;
using AMartinezTech.Domain.Module.Services;

namespace AMartinezTech.Application.Module.Services.UseCases.Write;

public class ServicePersistence(IServiceWriteRepository repository)
{
    private readonly IServiceWriteRepository _repository = repository;

    public async Task<Guid> ExecuteAsync(ServiceDto dto)
    {
        Guid _id = GeneratesId.Make(dto.Id);

        var entity = ServiceEntity.Create(_id, dto.Name, dto.Price, dto.WorkingTime, dto.Note);

        if (dto.Id == Guid.Empty) { await _repository.CreateAsync(entity); } else { await _repository.UpdateAsync(entity); }


        return _id;
    }
}
