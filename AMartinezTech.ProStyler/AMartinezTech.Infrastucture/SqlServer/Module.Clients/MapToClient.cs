using AMartinezTech.Domain.Module.Clients;
using Microsoft.Data.SqlClient;

namespace AMartinezTech.Infrastucture.SqlServer.Module.Clients;

internal class MapToClient
{
    internal static ClientEntity ToEntity(SqlDataReader reader)
    {
        return ClientEntity.Create(
            reader.GetGuid(reader.GetOrdinal("id")),
            reader.GetString(reader.GetOrdinal("name")),
            reader.GetString(reader.GetOrdinal("phone")),
            reader.GetString(reader.GetOrdinal("emil")),
            reader.GetDateTime(reader.GetOrdinal("created_at")));
    }
}
