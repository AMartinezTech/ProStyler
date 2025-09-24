using AMartinezTech.Domain.Module.Staff;
using AMartinezTech.Domain.Utils.Interfaces;

namespace AMartinezTech.Application.Module.Staff.Interfaces;

public interface IStaffReadRepository : IGetById<StaffEntity, Guid>, IFilter<StaffEntity>;