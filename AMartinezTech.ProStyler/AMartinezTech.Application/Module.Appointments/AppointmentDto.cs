namespace AMartinezTech.Application.Module.Appointments;

public class AppointmentDto
{
    public Guid Id { get; set; }
    public Guid StaffId { get; set; }
    public string StaffName { get; set; } = string.Empty;
    public Guid ClientId { get; set; }
    public string ClientName { get; set; } = string.Empty;
    public TimeOnly AsignedTime { get; set; }
    public TimeOnly LimitTime { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Status { get; set; } = "Pendiente";
    public List<AppointmentServiceDto> Services { get; set; } = [];
}
