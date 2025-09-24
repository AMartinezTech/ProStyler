using AMartinezTech.Application.Module.Appointments.Interfaces;
using AMartinezTech.Domain.Utils;

namespace AMartinezTech.Application.Module.Appointments.UseCases.Read;

public class AppointmentGetByDate(IAppointmentReadRepository repository)
{
    private readonly IAppointmentReadRepository _repository = repository;

    public async Task<ByDateResult<AppointmentDto>> ExecuteAsync(DateTime initialDate, DateTime endDate, bool? isactived)
    {
        var result = await _repository.GetByDateAsync(initialDate, endDate, isactived);
        var dtoList = AppointmentMapper.ToDtoList(result.Data);

        return new ByDateResult<AppointmentDto>(initialDate, endDate, dtoList);
    }
}
