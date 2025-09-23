using AMartinezTech.Domain.Utils.Exceptions;
using AMartinezTech.Domain.Utils.ValueObjects;

namespace AMartinezTech.Domain.Module.Products;

public class ProductEntity
{

    public Guid Id { get; private set; }
    public Guid CategoryId { get; private set; }
    public string Name { get; private set; }
    public ValuePositiveNum Price { get; private set; }
    public decimal Stock { get; private set; }
    public bool IsActived { get; private set; } = true;
    private ProductEntity(Guid id, Guid categoryId, string name, ValuePositiveNum price, decimal stock)
    {
        Id = id;
        CategoryId = categoryId;
        Name = name;
        Price = price;
        Stock = stock;
    }

    public static ProductEntity Create(Guid id, Guid categoryId, string name, decimal price, decimal stock)
    {
        if (string.IsNullOrWhiteSpace(name.Trim())) throw new Exception($"{ErrorMessages.Get(ErrorType.RequiredField)} - name");
        if (name.Length < 8) throw new Exception($"{ErrorMessages.Get(ErrorType.MinLength)} 8 - name");

        return new ProductEntity(id, categoryId, name, ValuePositiveNum.Create(price, "price"), stock);
    }

    public void Activate() => IsActived = true;
    public void Deactivate() => IsActived = false;
}
