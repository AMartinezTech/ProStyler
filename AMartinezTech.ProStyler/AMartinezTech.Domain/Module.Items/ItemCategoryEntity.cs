namespace AMartinezTech.Domain.Module.Items;

public class ItemCategoryEntity
{
    public Guid Id { get; private set; }
    public ValueItemCategoryName Name { get; private set; }
    public bool IsActived { get; private set; }  

    private ItemCategoryEntity(Guid id, ValueItemCategoryName name, bool isActived)
    {
        Id = id;
        Name = name;
        IsActived = isActived;
    }
    public static ItemCategoryEntity Create(Guid id, string name, bool isActived = true)
    {
        return new ItemCategoryEntity(id, ValueItemCategoryName.Create(name), isActived);
    }
 
}
