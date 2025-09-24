using AMartinezTech.Application.Module.Clients.Interfaces;
using AMartinezTech.Domain.Module.Clients;

namespace AMartinezTech.Application.Module.Clients.UseCases.Write;

public class ClientPersistence(IClientWriteRepository repository)
{
    private readonly IClientWriteRepository _repository = repository;

    public async Task<Guid> ExecuteAsync(ClientDto dto)
    {
        var id = dto.Id  == Guid.Empty ? Guid.NewGuid() : dto.Id;

        var entity = ClientEntity.Create(id, dto.Name, dto.Phone, dto.Email, dto.CreatedAt);

        if (dto.Id == Guid.Empty) { await _repository.CreateAsync(entity); } else { await _repository.UpdateAsync(entity); }
        return entity.Id;
    }
}
