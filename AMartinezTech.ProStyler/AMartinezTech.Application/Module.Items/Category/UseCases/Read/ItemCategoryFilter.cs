using AMartinezTech.Application.Module.Items.Category.Interfaces; 

namespace AMartinezTech.Application.Module.Items.Category.UseCases.Read;

public class ItemCategoryFilter(IItemCategoryReadRepository repository)
{
    private readonly IItemCategoryReadRepository _repository = repository;

    public async Task<List<ItemCategoryDto>> ExecuteAsync(string? filterStr, bool? isActived)
    {
        var result = await _repository.FilterAsync(filterStr, isActived);
        return ItemCategoryMapper.ToDtoList(result);
    }
}
