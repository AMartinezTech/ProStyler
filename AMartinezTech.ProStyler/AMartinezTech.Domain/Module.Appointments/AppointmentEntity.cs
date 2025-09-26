using AMartinezTech.Domain.Utils.Enums;
using AMartinezTech.Domain.Utils.ValueObjects;

namespace AMartinezTech.Domain.Module.Appointments;

public class AppointmentEntity
{
    public Guid Id { get; private set; }
    public ValueGuid StaffId { get; private set; }
    public string StaffName { get; private set; }
    public ValueGuid ClientId { get; private set; }
    public string ClientName { get; private set; }
    public TimeOnly AsignedTime { get; private set; }
    public TimeOnly LimitTime { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public ValueEnum<AppointmentStatus> Status { get; private set; }

    private readonly List<AppointmentServiceEntity> _services = [];
    public IReadOnlyCollection<AppointmentServiceEntity> Services => _services.AsReadOnly();

    private AppointmentEntity(Guid id, ValueGuid staffId, string staffName, ValueGuid clientId, string clientName, TimeOnly asignedTime, TimeOnly limitTime, DateTime createdAt, ValueEnum<AppointmentStatus> status)
    {
        Id = id;
        StaffId = staffId;
        StaffName = staffName;
        ClientId = clientId;
        ClientName = clientName;
        AsignedTime = asignedTime;
        LimitTime = limitTime;
        CreatedAt = createdAt;
        Status = status;
    }

    public static AppointmentEntity Create(Guid id, Guid staffId, string staffName, Guid clientId, string clientName, TimeOnly asignedTime, TimeOnly limitTime, DateTime createdAt, string status)
    {
        return new AppointmentEntity(id, ValueGuid.Create(staffId,"staff"), staffName, ValueGuid.Create(clientId,"client"), clientName, asignedTime, limitTime, createdAt, ValueEnum<AppointmentStatus>.Create(status));
    }
    public void AddService(AppointmentServiceEntity service)
    {
        _services.Add(service);
    }
}
