using AMartinezTech.Domain.Module.Administration;
using Microsoft.Data.SqlClient;

namespace AMartinezTech.Infrastucture.SqlServer.Module.Administration.Settings;

internal class MapToSetting
{
    internal static SettingEntity ToEntity(SqlDataReader reader)
    {
        return SettingEntity.Create(
            reader.GetGuid(reader.GetOrdinal("id")),
            reader.GetString(reader.GetOrdinal("company_name")),
            reader.GetString(reader.GetOrdinal("line1")),
            reader.GetString(reader.GetOrdinal("line2")),
            reader.GetString(reader.GetOrdinal("line3")),
            reader.GetString(reader.GetOrdinal("invoice_note")),
            reader.GetString(reader.GetOrdinal("invoice_print_name")),
            reader.GetString(reader.GetOrdinal("invoice_print_type"))
            );
    }
}
