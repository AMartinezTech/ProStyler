using AMartinezTech.Domain.Module.Items;
using Microsoft.Data.SqlClient;

namespace AMartinezTech.Infrastucture.SqlServer.Module.Items;

internal class MapToItem
{
    internal static ItemEntity ToEntity(SqlDataReader reader)
    {
        return ItemEntity.Create(
             reader.GetGuid(reader.GetOrdinal("id")),
             reader.GetString(reader.GetOrdinal("item_type")),
             reader.GetGuid(reader.GetOrdinal("category_id")),
             reader.GetString(reader.GetOrdinal("category_name")),
             reader.GetString(reader.GetOrdinal("name")),
             reader.GetDecimal(reader.GetOrdinal("price")),
             reader.GetDecimal(reader.GetOrdinal("stock")),
             bool.Parse(reader.GetString(reader.GetOrdinal("generates_commission"))),
             bool.Parse(reader.GetString(reader.GetOrdinal("is_actived"))));
    }
}
