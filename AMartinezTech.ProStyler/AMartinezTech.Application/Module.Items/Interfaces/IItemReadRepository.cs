using AMartinezTech.Domain.Module.Items;
using AMartinezTech.Domain.Utils.Interfaces;

namespace AMartinezTech.Application.Module.Items.Interfaces;

public interface IItemReadRepository : IFilter<ItemEntity>, IGetById<ItemEntity, Guid>, IPagination<ItemEntity>;
