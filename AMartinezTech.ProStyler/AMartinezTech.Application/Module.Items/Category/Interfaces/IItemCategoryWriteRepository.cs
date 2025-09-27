using AMartinezTech.Domain.Module.Items;
using AMartinezTech.Domain.Utils.Interfaces;

namespace AMartinezTech.Application.Module.Items.Category.Interfaces;

public interface IItemCategoryWriteRepository : ICreate<ItemCategoryEntity>, IUpdate<ItemCategoryEntity>;
