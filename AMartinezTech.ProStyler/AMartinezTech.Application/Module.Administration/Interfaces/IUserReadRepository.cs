using AMartinezTech.Domain.Module.Administration;
using AMartinezTech.Domain.Utils.Interfaces;

namespace AMartinezTech.Application.Module.Administration.Interfaces;

public interface IUserReadRepository : IGetById<UserEntity,Guid>, IFilter<UserEntity> 
{
    Task<UserEntity> LoginAsync(string userName, string password);
}