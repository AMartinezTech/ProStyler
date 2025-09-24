using AMartinezTech.Domain.Module.Clients;

namespace AMartinezTech.Application.Module.Clients;

internal class ClientMapper
{
    internal static ClientDto ToDto(ClientEntity entity)
    {
        return new ClientDto
        {
            Id = entity.Id,
            Name = entity.Name.Value,
            Phone = entity.Phone.Value,
            Email = entity.Email,
            CreatedAt = entity.CreatedAt,
        };
    }

    public static List<ClientDto> ToDtoList(IEnumerable<ClientEntity> entities) 
    {
        return [.. entities.Select(ToDto).ToList()];    
    }
}
