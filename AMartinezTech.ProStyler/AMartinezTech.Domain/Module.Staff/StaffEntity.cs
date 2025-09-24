using AMartinezTech.Domain.Utils.Exceptions;
using AMartinezTech.Domain.Utils.ValueObjects; 

namespace AMartinezTech.Domain.Module.Staff;

public class StaffEntity
{
    public Guid Id { get; private set; }
    public ValueName Name { get; private set; }
    public ValuePhone Phone { get; private set; }
    public string? Specialties { get; private set; }
    public bool IsActived { get; private set; }
    public decimal CommissionFeeByProdut {  get; private set; }
    public decimal CommissionFeeByService {  get; private set; }

    private StaffEntity(Guid id, ValueName name, ValuePhone phone, string? specialties, bool isActived, decimal commissionFeeByProduct, decimal commissionFeeByService)
    {
        Id = id;
        Name = name;
        Phone = phone;
        Specialties = specialties;
        IsActived = isActived;
        CommissionFeeByProdut = commissionFeeByProduct;
        CommissionFeeByService = commissionFeeByService;
    }

    public static StaffEntity Create(Guid id, string name, string phone, string? specialties, bool isActived, decimal commissionFeeByProduct, decimal commissionFeeByService)
    {
        if (commissionFeeByProduct < 0 || commissionFeeByProduct > 10) throw new Exception($"{ErrorMessages.Get(ErrorType.RangeValid)} 0 y 10 - commissionFeeByProduct");
        if (commissionFeeByService < 0 || commissionFeeByService > 10) throw new Exception($"{ErrorMessages.Get(ErrorType.RangeValid)} 0 y 10 - commissionFeeByProduct");

        return new StaffEntity(id, ValueName.Create(name), ValuePhone.Create(phone,"phone"), specialties, isActived,commissionFeeByProduct,commissionFeeByService);
    }
}
