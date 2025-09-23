using AMartinezTech.Domain.Utils.ValueObjects; 

namespace AMartinezTech.Domain.Module.Clients;

public class ClientEntity
{
    public Guid Id { get; private set; }
    public ValueUserName Name { get; private set; }
    public ValuePhone Phone { get; private set; }
    public string? Email { get; private set; }
    public DateTime CreatedAt { get; private set; }

    private ClientEntity(Guid id, ValueUserName name, ValuePhone phone, string? email, DateTime createdAt)
    {
        Id = id;
        Name = name;
        Phone = phone;
        Email = email;
        CreatedAt = createdAt;
    }

    public static ClientEntity Create(Guid id, string name, string phone, string? email, DateTime createdAt)
    {
        return new ClientEntity(id, ValueUserName.Create(name), ValuePhone.Create(phone,"phone"), email, createdAt);
    }

}
