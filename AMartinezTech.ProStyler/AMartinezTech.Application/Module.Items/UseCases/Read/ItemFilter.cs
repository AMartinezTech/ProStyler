using AMartinezTech.Application.Module.Items.Interfaces;

namespace AMartinezTech.Application.Module.Items.UseCases.Read;

public class ItemFilter(IItemReadRepository repository)
{
    private readonly IItemReadRepository _repository = repository;

    public async Task<List<ItemDto>> ExecuteAsync(string? filterStr, bool? isActived)
    {
        var result = await _repository.FilterAsync(filterStr, isActived);
        return ItemMapper.ToDtoList(result);
    }
}

