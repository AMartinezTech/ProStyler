using AMartinezTech.Domain.Module.Administration;

namespace AMartinezTech.Application.Module.Administration.Users;

internal class UserMapper
{
    internal static UserDto ToDto(UserEntity entity)
    {
        return new UserDto
        {
            Id = entity.Id,
            Name = entity.Name.Value,
            UserName = entity.UserName.Value, 
            Rol = entity.Rol.ToString(),
            IsActived = entity.IsActived,
        };
    }

    internal static List<UserDto> ToDtoList(IEnumerable<UserEntity> entities) 
    {
        return [.. entities.Select(ToDto).ToList() ];
    }
}
