using AMartinezTech.Domain.Module.Items;

namespace AMartinezTech.Application.Module.Items.Category;

internal class ItemCategoryMapper
{
    internal static ItemCategoryDto ToDto(ItemCategoryEntity entity)
    {
        return new ItemCategoryDto
        {
            Id = entity.Id,
            Name = entity.Name.Value,
            IsActived = entity.IsActived,
        };
    }

    internal static List<ItemCategoryDto> ToDtoList(IEnumerable<ItemCategoryEntity> entities) 
    {
        return [.. entities.Select(ToDto).ToList()];
    }
}
