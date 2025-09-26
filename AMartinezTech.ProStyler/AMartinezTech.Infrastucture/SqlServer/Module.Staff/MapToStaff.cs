using AMartinezTech.Domain.Module.Staff;
using Microsoft.Data.SqlClient;

namespace AMartinezTech.Infrastucture.SqlServer.Module.Staff;

internal class MapToStaff
{
    internal static StaffEntity ToEntity(SqlDataReader reader)
    {
        return StaffEntity.Create(
            reader.GetGuid(reader.GetOrdinal("id")),
            reader.GetString(reader.GetOrdinal("name")),
            reader.GetString(reader.GetOrdinal("phone")),
            reader.GetString(reader.GetOrdinal("specialties")),
            bool.Parse(reader.GetOrdinal("is_actived").ToString()),
            reader.GetDecimal(reader.GetOrdinal("commision_fee_by_product")),
            reader.GetDecimal(reader.GetOrdinal("commision_fee_by_service"))
            );
    }
}
