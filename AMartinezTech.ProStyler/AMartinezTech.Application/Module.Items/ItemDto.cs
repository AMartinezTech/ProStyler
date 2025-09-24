 
namespace AMartinezTech.Application.Module.Items;

public class ItemDto
{
    public Guid Id { get; set; }
    public string ItemType { get; set; } = "Producto";
    public Guid CategoryId { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public decimal Stock { get; set; }
    public bool IsActived { get; set; } = true;
    public bool GeneratesCommission { get; set; }
}
