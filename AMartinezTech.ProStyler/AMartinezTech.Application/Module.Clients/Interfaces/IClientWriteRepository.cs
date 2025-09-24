using AMartinezTech.Domain.Module.Clients;
using AMartinezTech.Domain.Utils.Interfaces;

namespace AMartinezTech.Application.Module.Clients.Interfaces;

public interface IClientWriteRepository : ICreate<ClientEntity>, IUpdate<ClientEntity>; 
