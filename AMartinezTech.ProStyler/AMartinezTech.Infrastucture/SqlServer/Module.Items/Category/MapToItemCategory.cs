using AMartinezTech.Domain.Module.Items;
using Microsoft.Data.SqlClient;

namespace AMartinezTech.Infrastucture.SqlServer.Module.Items.Category;

internal class MapToItemCategory
{
    internal static ItemCategoryEntity ToEntity(SqlDataReader reader)
    {
        return ItemCategoryEntity.Create(
            reader.GetGuid(reader.GetOrdinal("id")),
            reader.GetString(reader.GetOrdinal("name")),
            bool.Parse(reader.GetString(reader.GetOrdinal("is_actived")))
            );
    }
}
