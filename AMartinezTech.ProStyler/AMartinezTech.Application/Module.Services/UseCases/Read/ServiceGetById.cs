using AMartinezTech.Application.Module.Services.Interfaces;

namespace AMartinezTech.Application.Module.Services.UseCases.Read;

public class ServiceGetById(IServiceReadRepository repository)
{
    private readonly IServiceReadRepository _repository = repository;

    public async Task<ServiceDto> ExecuteAsync(Guid id)
    {
        var result = await _repository.GetByIdAsync(id);
        return ServiceMapper.ToDto(result);
    }
}
