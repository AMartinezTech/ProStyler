using AMartinezTech.Domain.Utils.Enums;
using AMartinezTech.Domain.Utils.ValueObjects;

namespace AMartinezTech.Domain.Module.Administration;

public class UserEntity
{
    public Guid Id { get; private set; }
    public ValueName Name { get; private set; }
    public ValueUserName UserName { get; private set; }
    public ValuePassword Password { get; private set; }
    public ValueEnum<RolType> Rol { get; private set; }
    private UserEntity(Guid id, ValueName name, ValueUserName userName, ValuePassword password, ValueEnum<RolType> rol)
    {
        Id = id;
        Name = name;
        UserName = userName;
        Password = password;
        Rol = rol;
    }

    public static UserEntity Create(Guid id, string name, string userName, string password, string rol)
    {
        return new UserEntity(id, ValueName.Create(name), ValueUserName.Create(userName), ValuePassword.Create(password), ValueEnum<RolType>.Create(rol));
    }
}
