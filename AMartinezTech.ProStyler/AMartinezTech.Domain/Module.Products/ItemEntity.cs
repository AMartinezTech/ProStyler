using AMartinezTech.Domain.Utils.Enums;
using AMartinezTech.Domain.Utils.Exceptions;
using AMartinezTech.Domain.Utils.ValueObjects;

namespace AMartinezTech.Domain.Module.Products;

public class ItemEntity
{

    public Guid Id { get; private set; }
    public ValueEnum<ItemType> Type { get; private set; }
    public Guid CategoryId { get; private set; }
    public string Name { get; private set; }
    public ValuePositiveNum Price { get; private set; }
    public decimal Stock { get; private set; }
    public bool IsActived { get; private set; } = true;
    private ItemEntity(Guid id, ValueEnum<ItemType> type, Guid categoryId, string name, ValuePositiveNum price, decimal stock)
    {
        Id = id;
        Type = type;
        CategoryId = categoryId;
        Name = name;
        Price = price;
        Stock = stock;
    }

    public static ItemEntity Create(Guid id, string type, Guid categoryId, string name, decimal price, decimal stock)
    {
        if (string.IsNullOrWhiteSpace(name.Trim())) throw new Exception($"{ErrorMessages.Get(ErrorType.RequiredField)} - name");
        if (name.Length < 8) throw new Exception($"{ErrorMessages.Get(ErrorType.MinLength)} 8 - name");

        return new ItemEntity(id, ValueEnum<ItemType>.Create(type), categoryId, name, ValuePositiveNum.Create(price, "price"), stock);
    }

    public void Activate() => IsActived = true;
    public void Deactivate() => IsActived = false;
}
