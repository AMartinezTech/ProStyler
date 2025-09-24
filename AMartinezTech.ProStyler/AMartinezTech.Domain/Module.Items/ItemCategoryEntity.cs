namespace AMartinezTech.Domain.Module.Items;

public class ItemCategoryEntity
{
    public Guid Id { get; private set; }
    public ValueItemCategoryName Name { get; private set; }
    public bool IsActived { get; private set; } = true;

    private ItemCategoryEntity(Guid id, ValueItemCategoryName name)
    {
        Id = id;
        Name = name;
    }
    public static ItemCategoryEntity Create(Guid id, string name)
    {
        return new ItemCategoryEntity(id, ValueItemCategoryName.Create(name));
    }

    public void Activate() => IsActived = true;
    public void Deactivate() => IsActived = false;
}
