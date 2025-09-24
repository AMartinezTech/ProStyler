namespace AMartinezTech.Application.Module.Staff;

public class StaffDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string? Specialties { get; set; }
    public bool IsActived { get; set; }
    public decimal CommissionFeeByProduct { get; set; }
    public decimal CommissionFeeByService { get; set; }
}
