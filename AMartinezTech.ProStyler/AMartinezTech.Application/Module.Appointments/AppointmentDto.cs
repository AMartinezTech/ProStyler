namespace AMartinezTech.Application.Module.Appointments;

public class AppointmentDto
{
    public Guid Id { get; set; }
    public Guid StaffId { get; set; }
    public Guid ClientId { get; set; }
    public TimeOnly AsignedTime { get; set; }
    public TimeOnly LimitTime { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Status { get; set; } = "Pendiente";
}
