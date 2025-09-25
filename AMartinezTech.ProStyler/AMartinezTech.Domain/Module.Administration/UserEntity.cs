using AMartinezTech.Domain.Utils.Enums;
using AMartinezTech.Domain.Utils.ValueObjects;

namespace AMartinezTech.Domain.Module.Administration;

public class UserEntity
{
    public Guid Id { get; private set; }
    public ValueName Name { get; private set; }
    public ValueUserName UserName { get; private set; }
    public ValuePassword PasswordHash { get; private set; }
    public ValueEnum<RolType> Rol { get; private set; }
    public bool IsActived { get; private set; } = true;
    private UserEntity(Guid id, ValueName name, ValueUserName userName, ValuePassword passwordHash, ValueEnum<RolType> rol, bool isActived)
    {
        Id = id;
        Name = name;
        UserName = userName;
        PasswordHash = passwordHash;
        Rol = rol;
        IsActived = isActived;
    }

    public static UserEntity Create(Guid id, string name, string userName, string passwordHash, string rol, bool isActived)
    {
        return new UserEntity(id, ValueName.Create(name), ValueUserName.Create(userName), ValuePassword.Create(passwordHash), ValueEnum<RolType>.Create(rol), isActived);
    }

}
