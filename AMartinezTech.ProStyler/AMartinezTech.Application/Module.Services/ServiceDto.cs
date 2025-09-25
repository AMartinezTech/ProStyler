namespace AMartinezTech.Application.Module.Services;

public class ServiceDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public decimal WorkingTime { get; set; }
    public string? Note { get; set; }
    public bool IsActived { get; set; }  
} 