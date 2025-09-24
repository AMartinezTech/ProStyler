using AMartinezTech.Application.Module.Appointments.Interfaces;
using AMartinezTech.Domain.Utils;

namespace AMartinezTech.Application.Module.Appointments.UseCases.Read;

public class AppointmentPagination(IAppointmentReadRepository repository)
{
    private readonly IAppointmentReadRepository _repository = repository;

    public async Task<PageResult<AppointmentDto>> ExecuteAsync(int pageNumber, int pageSize, bool? isactived)
    {
        var result = await _repository.PaginationAsync(pageNumber, pageSize, isactived);
        var dtoList = AppointmentMapper.ToDtoList(result.Data);

        return new PageResult<AppointmentDto>(result.TotalRecords, pageSize, dtoList);
    }
}
