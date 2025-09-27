using AMartinezTech.Application.Module.Items.Category.Interfaces; 

namespace AMartinezTech.Application.Module.Items.Category.UseCases.Read;

public class ItermCategoryGetById(IItemCategoryReadRepository repository)
{
    private readonly IItemCategoryReadRepository _repository = repository;

    public async Task<ItemCategoryDto> ExecuteAsync(Guid id)
    {
        var result = await _repository.GetByIdAsync(id);
        return ItemCategoryMapper.ToDto(result);
    }
}
