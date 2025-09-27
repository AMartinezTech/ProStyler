using AMartinezTech.Application.Module.Items.Category.Interfaces;
using AMartinezTech.Application.Utils;
using AMartinezTech.Domain.Module.Items;

namespace AMartinezTech.Application.Module.Items.Category.UseCases.Write;

public class ItemCategoryPersistence(IItemCategoryWriteRepository repository)
{
    private readonly IItemCategoryWriteRepository _repository = repository;

    public async Task<Guid> ExecuteAsync(ItemCategoryDto dto)
    {
        Guid _id = GeneratesId.Make(dto.Id);
        
        var entity = ItemCategoryEntity.Create(_id,dto.Name,dto.IsActived);

        if (dto.Id == Guid.Empty) { await _repository.CreateAsync(entity); } else { await _repository.UpdateAsync(entity); }

        return _id;
    }
}
