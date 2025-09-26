using AMartinezTech.Domain.Module.Administration;
using Microsoft.Data.SqlClient;

namespace AMartinezTech.Infrastucture.SqlServer.Module.Administration;

internal class MapToUser
{
    internal static UserEntity ToEntity(SqlDataReader reader)
    {
        return UserEntity.Create(
            reader.GetGuid(reader.GetOrdinal("id")),
             reader.GetString(reader.GetOrdinal("name")),
             reader.GetString(reader.GetOrdinal("user_name")),
             reader.GetString(reader.GetOrdinal("rol")),
             reader.GetString(reader.GetOrdinal("password")),
             bool.Parse(reader.GetString(reader.GetOrdinal("is_actived")))
            );
    }
}

