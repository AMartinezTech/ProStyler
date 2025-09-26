using AMartinezTech.Domain.Utils.ValueObjects;

namespace AMartinezTech.Domain.Module.Services;

public class ServiceEntity
{ 
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public ValuePositiveNum Price { get; private set; }
    public decimal WorkingTime { get; private set; } 
    public string? Note {  get; private set; }
    public bool IsActived { get; private set; } 

    private ServiceEntity(Guid id, string name, ValuePositiveNum price, decimal workingTime, string? note, bool isActived)
    {
        Id = id;
        Name = name;
        Price = price;
        WorkingTime = workingTime;
        Note = note;
        IsActived = isActived;
    }
    public static ServiceEntity Create(Guid id, string name, decimal price, decimal workingTime, string? note, bool isActived = true)
    {
        return new ServiceEntity(id, name, ValuePositiveNum.Create(price,"price"), workingTime, note, isActived);
    }

   
}
