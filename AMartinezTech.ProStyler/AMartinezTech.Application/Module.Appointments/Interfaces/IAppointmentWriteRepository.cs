using AMartinezTech.Domain.Module.Appointments;
using AMartinezTech.Domain.Utils.Interfaces;

namespace AMartinezTech.Application.Module.Appointments.Interfaces;

public interface IAppointmentWriteRepository : ICreate<AppointmentEntity>, IUpdate<AppointmentEntity>;
