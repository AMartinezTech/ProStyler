using AMartinezTech.Application.Module.Staff.Interfaces;

namespace AMartinezTech.Application.Module.Staff.UseCases.Read;

public class StaffGetById(IStaffReadRepository repository)
{
    private readonly IStaffReadRepository _repository = repository;

    public async Task<StaffDto> ExecuteAsync(Guid id)
    {
        var result = await _repository.GetByIdAsync(id);
        return StaffMapper.ToDto(result);
    }

}