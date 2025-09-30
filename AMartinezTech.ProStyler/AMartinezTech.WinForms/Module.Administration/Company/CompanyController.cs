using AMartinezTech.Application.Module.Administration.Settings;
using AMartinezTech.Application.Module.Administration.Settings.UseCases;

namespace AMartinezTech.WinForms.Module.Administration.Company;

public class CompanyController(SettingPagination pagination, SettingPersistence persistence)
{
    private readonly SettingPagination _pagination = pagination;
    private readonly SettingPersistence _persistence = persistence;
    public async Task<SettingDto> PaginationGetFirstAsync()
    {
        var result = await _pagination.ExecuteAsync(1, 10);

        return result.Data.FirstOrDefault() ?? new SettingDto();
    }

    public async Task<Guid> PersistenceAsync(SettingDto dto)
    {
       return await _persistence.ExecuteAsync(dto);
    }
}
