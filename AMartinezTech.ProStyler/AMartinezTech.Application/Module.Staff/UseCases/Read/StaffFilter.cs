using AMartinezTech.Application.Module.Staff.Interfaces;

namespace AMartinezTech.Application.Module.Staff.UseCases.Read;

public class StaffFilter(IStaffReadRepository repository)
{
    private readonly IStaffReadRepository _repository = repository;

    public async Task<List<StaffDto>> ExecuteAsync(string? filterStr, bool? isActived)
    {
        var result = await _repository.FilterAsync(filterStr, isActived);
        return StaffMapper.ToDtoList(result);
    }
}
