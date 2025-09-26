using AMartinezTech.Domain.Module.Services;
using Microsoft.Data.SqlClient;

namespace AMartinezTech.Infrastucture.SqlServer.Module.Services;

internal class MapToService
{
    internal static ServiceEntity ToEntity(SqlDataReader reader)
    {
        return ServiceEntity.Create(
            reader.GetGuid(reader.GetOrdinal("id")),
            reader.GetString(reader.GetOrdinal("name")),
            reader.GetDecimal(reader.GetOrdinal("price")),
            reader.GetDecimal(reader.GetOrdinal("working_time")),
            reader.GetString(reader.GetOrdinal("note")),
            bool.Parse(reader.GetString(reader.GetOrdinal("is_actived")))
            );
    }
}
