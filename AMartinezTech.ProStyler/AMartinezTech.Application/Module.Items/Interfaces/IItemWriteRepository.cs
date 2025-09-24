using AMartinezTech.Domain.Module.Items;
using AMartinezTech.Domain.Utils.Interfaces;

namespace AMartinezTech.Application.Module.Items.Interfaces;

public interface IItemWriteRepository : ICreate<ItemEntity>, IUpdate<ItemEntity>;
