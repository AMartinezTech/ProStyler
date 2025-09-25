namespace AMartinezTech.Application.Module.Appointments;

public class AppointmentServiceDto
{
    public Guid AppointmentId { get; set; }
    public Guid ServiceId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}
