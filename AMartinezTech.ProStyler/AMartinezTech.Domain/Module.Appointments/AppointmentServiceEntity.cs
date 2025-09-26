namespace AMartinezTech.Domain.Module.Appointments;

public class AppointmentServiceEntity
{
    public Guid AppointmentId { get; private set; }
    public Guid ServiceId { get; private set; }
    public string ServiceName { get; private set; }
    public int Quantity { get; private set; }
    public decimal Price { get; private set; }

    private AppointmentServiceEntity(Guid appointmentId, Guid serviceId, string serviceName, int quantity, decimal price)
    {
        AppointmentId = appointmentId;
        ServiceId = serviceId;
        ServiceName = serviceName;
        Quantity = quantity;
        Price = price;
    }

    public static AppointmentServiceEntity Create(Guid appointmentId, Guid serviceId, string serviceName, int quantity, decimal price)
    {
        return new AppointmentServiceEntity(appointmentId, serviceId, serviceName, quantity, price);
    }
}
