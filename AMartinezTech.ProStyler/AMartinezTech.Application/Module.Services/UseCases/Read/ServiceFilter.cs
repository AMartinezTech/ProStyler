using AMartinezTech.Application.Module.Services.Interfaces;

namespace AMartinezTech.Application.Module.Services.UseCases.Read;

public class ServiceFilter(IServiceReadRepository repository)
{
    private readonly IServiceReadRepository _repository = repository;

    public async Task<List<ServiceDto>> ExecuteAsync(string? filterStr, bool? isActived)
    {
        var result = await _repository.FilterAsync(filterStr, isActived);
        return ServiceMapper.ToDtoList(result);
    }
}
