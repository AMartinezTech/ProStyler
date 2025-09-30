using AMartinezTech.Application.Module.Administration.Settings.Interfaces;
using AMartinezTech.Domain.Utils;

namespace AMartinezTech.Application.Module.Administration.Settings.UseCases;

public class SettingPagination(ISettingReadRepository repository)
{
    private readonly ISettingReadRepository _repository = repository;

    public async Task<PageResult<SettingDto>> ExecuteAsync(int pageNumber, int pageSize)
    {
        var result = await _repository.PaginationAsync(pageNumber, pageSize, null);
        var dtoList = result.Data.Select(SettingMapper.ToDto).ToList();

        return new PageResult<SettingDto>(result.TotalRecords, pageSize, dtoList);
    }
}
