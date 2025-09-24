using AMartinezTech.Application.Module.Appointments.Interfaces; 
namespace AMartinezTech.Application.Module.Appointments.UseCases.Read;

public class AppointmentGetById(IAppointmentReadRepository repository)
{
    private readonly IAppointmentReadRepository _repository = repository;

    public async Task<AppointmentDto> ExecuteAsync(Guid id)
    {
        var result = await _repository.GetById(id);
        return AppointmentMapper.ToDto(result);
    }
}
