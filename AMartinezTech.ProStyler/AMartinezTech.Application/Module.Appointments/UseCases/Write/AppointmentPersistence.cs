using AMartinezTech.Application.Module.Appointments.Interfaces;
using AMartinezTech.Application.Utils;
using AMartinezTech.Domain.Module.Appointments;

namespace AMartinezTech.Application.Module.Appointments.UseCases.Write;

public class AppointmentPersistence(IAppointmentWriteRepository repository)
{
    private readonly IAppointmentWriteRepository _repository = repository;

    public async Task<Guid> ExecuteAsync(AppointmentDto dto)
    {
        Guid _id = GeneratesId.Make(dto.Id);

        var entity = AppointmentEntity.Create(_id, dto.StaffId, dto.ClientId, dto.AsignedTime, dto.LimitTime, dto.CreatedAt, dto.Status);

        if (dto.Id == Guid.Empty) { await _repository.CreateAsync(entity); } else { await _repository.UpdateAsync(entity); }
        return _id;
    }
}
