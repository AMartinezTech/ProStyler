using AMartinezTech.Domain.Module.Administration;
using Microsoft.Data.SqlClient;

namespace AMartinezTech.Infrastucture.SqlServer.Module.Administration.Users;

internal class MapToUser
{
    internal static UserEntity ToEntity(SqlDataReader reader)
    {
        return UserEntity.Create(
            reader.GetGuid(reader.GetOrdinal("id")),
             reader.GetString(reader.GetOrdinal("name")),
             reader.GetString(reader.GetOrdinal("user_name")),
             ValuePassword.FromHash(reader.GetString(reader.GetOrdinal("password"))),
             reader.GetString(reader.GetOrdinal("rol")),
             reader.GetBoolean(reader.GetOrdinal("is_actived"))
            );
    }
}

