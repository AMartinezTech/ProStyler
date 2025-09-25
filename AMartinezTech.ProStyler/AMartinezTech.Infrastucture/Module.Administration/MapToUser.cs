using AMartinezTech.Domain.Module.Administration;
using Microsoft.Data.SqlClient;

namespace AMartinezTech.Infrastucture.Module.Administration;

internal class MapToUser
{
    internal static UserEntity ToEntity(SqlDataReader reader)
    {
        return UserEntity.Create(
            reader.GetGuid(reader.GetOrdinal("id")),
             reader.GetOrdinal("name").ToString(),
             reader.GetOrdinal("user_name").ToString(),
             reader.GetOrdinal("rol").ToString(),
             reader.GetOrdinal("password").ToString(),
             bool.Parse(reader.GetOrdinal("is_actived").ToString())
            );
    }
}
