using AMartinezTech.Domain.Module.Services;
using AMartinezTech.Domain.Utils.Interfaces;

namespace AMartinezTech.Application.Module.Services.Interfaces;

public interface IServiceWriteRepository : ICreate<ServiceEntity>, IUpdate<ServiceEntity>;
