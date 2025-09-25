using AMartinezTech.Domain.Module.Services;

namespace AMartinezTech.Application.Module.Services;

internal class ServiceMapper
{
    internal static ServiceDto ToDto(ServiceEntity entity)
    {
        return new ServiceDto
        {
            Id = entity.Id,
            Name = entity.Name,
            Price = entity.Price.Value,
            Note = entity.Note,
            WorkingTime = entity.WorkingTime,
            IsActived = entity.IsActived,
        };
    }

    internal static List<ServiceDto> ToDtoList(IEnumerable<ServiceEntity> entities) 
    { 
        return [.. entities.Select(ToDto).ToList()];
    }
}
