using AMartinezTech.Domain.Module.Items;

namespace AMartinezTech.Application.Module.Items;

internal class ItemMapper
{
    internal static ItemDto ToDto(ItemEntity entity)
    {
        return new ItemDto
        {
            Id = entity.Id,
            ItemType = entity.ItemType.ToString(),
            CategoryId = entity.CategoryId.Value,
            CategoryName = entity.CategoryName,
            Name = entity.Name,
            Price = entity.Price.Value,
            Stock = entity.Stock,
            IsActived = entity.IsActived,
            GeneratesCommission = entity.GeneratesCommission
        };
    }

    internal static List<ItemDto> ToDtoList(IEnumerable<ItemEntity> entities) 
    { 
        return [.. entities.Select(ToDto).ToList()];
    }
}
