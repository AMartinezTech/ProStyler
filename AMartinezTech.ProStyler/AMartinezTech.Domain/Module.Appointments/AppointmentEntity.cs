using AMartinezTech.Domain.Utils.Enums;
using AMartinezTech.Domain.Utils.ValueObjects;

namespace AMartinezTech.Domain.Module.Appointments;

public class AppointmentEntity
{
    public Guid Id { get; private set; }
    public Guid StaffId { get; private set; }
    public Guid ClientId { get; private set; }
    public TimeOnly AsignedTime { get; private set; }
    public TimeOnly LimitTime { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public ValueEnum<AppointmentStatus> Status { get; private set; }

    private AppointmentEntity(Guid id, Guid staffId, Guid clientId, TimeOnly asignedTime, TimeOnly limitTime, DateTime createdAt, ValueEnum<AppointmentStatus> status)
    {
        Id = id;
        StaffId = staffId;
        ClientId = clientId;
        AsignedTime = asignedTime;
        LimitTime = limitTime;
        CreatedAt = createdAt;
        Status = status;
    }

    public static AppointmentEntity Create(Guid id, Guid staffId, Guid clientId, TimeOnly asignedTime, TimeOnly limitTime, DateTime createdAt, string status)
    {
        return new AppointmentEntity(id, staffId, clientId, asignedTime, limitTime, createdAt, ValueEnum<AppointmentStatus>.Create(status));
    }
}
