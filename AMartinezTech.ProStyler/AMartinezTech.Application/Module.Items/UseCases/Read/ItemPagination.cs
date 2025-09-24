using AMartinezTech.Application.Module.Items.Interfaces;
using AMartinezTech.Domain.Utils;

namespace AMartinezTech.Application.Module.Items.UseCases.Read;

public class ItemPagination(IItemReadRepository repository)
{
    private readonly IItemReadRepository _repository = repository;
    
    public async Task<PageResult<ItemDto>> ExecuteAsync(int pageNumber, int pageSize, bool? isActived)
    {
        var result = await _repository.PaginationAsync(pageNumber, pageSize, isActived);
        var dtoList = ItemMapper.ToDtoList(result.Data);

        return new PageResult<ItemDto>(result.TotalRecords, pageSize, dtoList);
    }
}
