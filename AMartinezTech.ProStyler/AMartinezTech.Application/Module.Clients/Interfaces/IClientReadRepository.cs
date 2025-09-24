using AMartinezTech.Domain.Module.Clients;
using AMartinezTech.Domain.Utils.Interfaces;

namespace AMartinezTech.Application.Module.Clients.Interfaces;

public interface IClientReadRepository : IGetById<ClientEntity, Guid>, IFilter<ClientEntity>;