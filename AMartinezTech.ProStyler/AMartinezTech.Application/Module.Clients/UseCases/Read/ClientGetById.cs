using AMartinezTech.Application.Module.Clients.Interfaces;

namespace AMartinezTech.Application.Module.Clients.UseCases.Read;

public class ClientGetById(IClientReadRepository repository)
{
    private readonly IClientReadRepository _repository = repository;
    public async Task<ClientDto> ExecuteAsync(Guid id)
    {
        var result = await _repository.GetById(id);
        return ClientMapper.ToDto(result);
    }
}
