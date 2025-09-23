namespace AMartinezTech.Domain.Module.Products;

public class ProductCategoryEntity
{
    public Guid Id { get; private set; }
    public ValueProductCategoryName Name { get; private set; }
    public bool IsActived { get; private set; } = true;

    private ProductCategoryEntity(Guid id, ValueProductCategoryName name)
    {
        Id = id;
        Name = name;
    }
    public static ProductCategoryEntity Create(Guid id, string name)
    {
        return new ProductCategoryEntity(id, ValueProductCategoryName.Create(name));
    }

    public void Activate() => IsActived = true;
    public void Deactivate() => IsActived = false;
}
