using AMartinezTech.Domain.Module.Staff;

namespace AMartinezTech.Application.Module.Staff;

internal class StaffMapper
{
    internal static StaffDto ToDto(StaffEntity entity)
    {
        return new StaffDto
        {
            Id = entity.Id,
            Name = entity.Name.Value,
            Phone = entity.Phone.Value,
            Specialties =entity.Specialties,
            IsActived = entity.IsActived,
            CommissionFeeByProduct = entity.CommissionFeeByProduct,
            CommissionFeeByService = entity.CommissionFeeByService,            
        };
    }

    internal static List<StaffDto> ToDtoList(IEnumerable<StaffEntity> entities) 
    {
        return [.. entities.Select(ToDto).ToList()];
    }
}
