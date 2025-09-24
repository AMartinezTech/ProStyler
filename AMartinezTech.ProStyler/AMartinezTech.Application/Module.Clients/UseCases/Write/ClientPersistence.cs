using AMartinezTech.Application.Module.Clients.Interfaces;
using AMartinezTech.Application.Utils;
using AMartinezTech.Domain.Module.Clients;

namespace AMartinezTech.Application.Module.Clients.UseCases.Write;

public class ClientPersistence(IClientWriteRepository repository)
{
    private readonly IClientWriteRepository _repository = repository;

    public async Task<Guid> ExecuteAsync(ClientDto dto)
    {
        Guid _id = GeneratesId.Make(dto.Id);

        var entity = ClientEntity.Create(_id, dto.Name, dto.Phone, dto.Email, dto.CreatedAt);

        if (dto.Id == Guid.Empty) { await _repository.CreateAsync(entity); } else { await _repository.UpdateAsync(entity); }
        return _id;
    }
}
