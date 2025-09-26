using AMartinezTech.Domain.Module.Appointments;

namespace AMartinezTech.Application.Module.Appointments;

internal class AppointmentMapper
{
    internal static AppointmentDto ToDto(AppointmentEntity entity)
    {
        var dto = new AppointmentDto
        {
            Id = entity.Id,
            StaffId = entity.StaffId.Value,
            StaffName = entity.StaffName,
            ClientId = entity.ClientId.Value,
            ClientName = entity.ClientName,
            AsignedTime = entity.AsignedTime,
            LimitTime = entity.LimitTime,
            CreatedAt = entity.CreatedAt,
            Status = entity.Status.Type.ToString(),
            Services = [.. entity.Services.Select(x => new AppointmentServiceDto
            {
                AppointmentId = x.AppointmentId,
                ServiceId = x.ServiceId,
                ServiceName = x.ServiceName,
                Price = x.Price,
                Quantity = x.Quantity   
            })],
        };
         

        return dto;
    }

    internal static List<AppointmentDto> ToDtoList(IEnumerable<AppointmentEntity> entities)
    {
        return [.. entities.Select(ToDto).ToList()];
    }
}
