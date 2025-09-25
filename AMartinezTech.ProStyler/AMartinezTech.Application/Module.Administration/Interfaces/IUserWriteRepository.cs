using AMartinezTech.Domain.Module.Administration;
using AMartinezTech.Domain.Utils.Interfaces;

namespace AMartinezTech.Application.Module.Administration.Interfaces;

public interface IUserWriteRepository : ICreate<UserEntity>, IUpdate<UserEntity>;
