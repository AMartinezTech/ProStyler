using AMartinezTech.Application.Module.Items.Interfaces;

namespace AMartinezTech.Application.Module.Items.UseCases.Read;

public class ItemGetById(IItemReadRepository repository )
{
    private readonly IItemReadRepository _repository = repository;

    public async Task<ItemDto> ExecuteAsync(Guid id)
    {
        var result = await _repository.GetById(id);
        return ItemMapper.ToDto(result);
    }
}
