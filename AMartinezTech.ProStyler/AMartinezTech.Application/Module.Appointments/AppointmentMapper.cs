using AMartinezTech.Domain.Module.Appointments;

namespace AMartinezTech.Application.Module.Appointments;

internal class AppointmentMapper
{
    internal static AppointmentDto ToDto(AppointmentEntity entity)
    {
        return new AppointmentDto
        {
            Id = entity.Id,
            StaffId = entity.StaffId,
            AsignedTime = entity.AsignedTime,
            LimitTime = entity.LimitTime,
            CreatedAt = entity.CreatedAt,
            Status = entity.Status.ToString(),
        };
    }

    internal static List<AppointmentDto> ToDtoList(IEnumerable<AppointmentEntity> entities) 
    {
        return [.. entities.Select(ToDto).ToList()];
    }
}
