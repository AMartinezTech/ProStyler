using AMartinezTech.Application.Module.Items.Interfaces;
using AMartinezTech.Application.Utils;
using AMartinezTech.Domain.Module.Items;

namespace AMartinezTech.Application.Module.Items.UseCases.Write;

public class ItemPersistence(IItemWriteRepository repository)
{
    private readonly IItemWriteRepository _repository = repository;

    public async Task<Guid> ExecuteAsync(ItemDto dto)
    {
        Guid _id = GeneratesId.Make(dto.Id);

        var entity = ItemEntity.Create(_id, dto.ItemType, dto.CategoryId, dto.CategoryName, dto.Name, dto.Price, dto.Stock, dto.GeneratesCommission, dto.IsActived );

        if (dto.Id == Guid.Empty) { await _repository.CreateAsync(entity); } else { await _repository.UpdateAsync(entity); }

        return _id;
    }
}
