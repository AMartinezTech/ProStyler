using AMartinezTech.Domain.Utils.Enums;
using AMartinezTech.Domain.Utils.Exceptions;
using AMartinezTech.Domain.Utils.ValueObjects;

namespace AMartinezTech.Domain.Module.Items;

public class ItemEntity
{ 
    public Guid Id { get; private set; }
    public ValueEnum<ItemType> ItemType { get; private set; }
    public ValueGuid CategoryId { get; private set; }
    public string CategoryName { get; private set; }
    public string Name { get; private set; }
    public ValuePositiveNum Price { get; private set; }
    public decimal Stock { get; private set; }
    public bool GeneratesCommission { get; private set; }
    public bool IsActived { get; private set; }  
    private ItemEntity(Guid id, ValueEnum<ItemType> itemType, ValueGuid categoryId, string categoryName,  string name, ValuePositiveNum price, decimal stock, bool generatesCommission, bool isActived)
    {
        Id = id;
        ItemType = itemType;
        CategoryId = categoryId;
        CategoryName = categoryName;
        Name = name;
        Price = price;
        Stock = stock;
        GeneratesCommission = generatesCommission;
    }

    public static ItemEntity Create(Guid id, string itemType, Guid categoryId, string categoryName, string name, decimal price, decimal stock, bool generatesCommission, bool isActived = true)
    {
        if (string.IsNullOrWhiteSpace(name.Trim())) throw new Exception($"{ErrorMessages.Get(ErrorType.RequiredField)} - name");
        if (name.Length < 8) throw new Exception($"{ErrorMessages.Get(ErrorType.MinLength)} 8 - name");

        return new ItemEntity(id, ValueEnum<ItemType>.Create(itemType), ValueGuid.Create(categoryId,"category"), categoryName, name, ValuePositiveNum.Create(price, "price"), stock, generatesCommission, isActived);
    }
 
}
