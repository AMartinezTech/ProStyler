using AMartinezTech.Domain.Module.Appointments;
using AMartinezTech.Domain.Utils.Interfaces;

namespace AMartinezTech.Application.Module.Appointments.Interfaces;

public interface IAppointmentReadRepository : IGetByDate<AppointmentEntity>, IGetById<AppointmentEntity, Guid>, IPagination<AppointmentEntity>;
