using AMartinezTech.Domain.Utils.ValueObjects; 

namespace AMartinezTech.Domain.Module.Staff;

public class StaffEntity
{
    public Guid Id { get; private set; }
    public ValueName Name { get; private set; }
    public ValuePhone Phone { get; private set; }
    public string? Specialties { get; private set; }

    private StaffEntity(Guid id, ValueName name, ValuePhone phone, string? specialties)
    {
        Id = id;
        Name = name;
        Phone = phone;
        Specialties = specialties;
    }

    public static StaffEntity Create(Guid id, string name, string phone, string? specialties)
    {
        return new StaffEntity(id, ValueName.Create(name), ValuePhone.Create(phone,"phone"), specialties);
    }
}
