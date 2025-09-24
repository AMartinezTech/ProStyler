using AMartinezTech.Application.Module.Clients.Interfaces;

namespace AMartinezTech.Application.Module.Clients.UseCases.Read;

public class ClientFilter(IClientReadRepository repository)
{
    private readonly IClientReadRepository _repository = repository;
    
    public async Task<List<ClientDto>> ExecuteAsync(string? filterStr, bool? isActived)
    {
        var result = await _repository.FilterAsync(filterStr, isActived);
        return ClientMapper.ToDtoList(result);
    }
}
