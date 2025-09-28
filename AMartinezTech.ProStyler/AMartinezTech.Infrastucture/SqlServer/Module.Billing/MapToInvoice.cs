using AMartinezTech.Domain.Module.Billing; 
using Microsoft.Data.SqlClient;

namespace AMartinezTech.Infrastucture.SqlServer.Module.Billing;

internal class MapToInvoice
{
    internal static InvoiceEntity Header(SqlDataReader reader)
    {
        return InvoiceEntity.Create(
            reader.GetGuid(reader.GetOrdinal("id")),
            reader.GetGuid(reader.GetOrdinal("client_id")),
            reader.GetString(reader.GetOrdinal("client_name")),
            reader.GetGuid(reader.GetOrdinal("staff_id")),
            reader.GetString(reader.GetOrdinal("staff_name")),
            reader.GetDateTime(reader.GetOrdinal("created_at")),
            reader.GetString(reader.GetOrdinal("status")));
    }

    internal static InvoiceDetailEntity Details(SqlDataReader reader)
    {
        return InvoiceDetailEntity.Create( 
            reader.GetGuid(reader.GetOrdinal("invoice_id")),
            reader.GetString(reader.GetOrdinal("item_type")),
            reader.GetString(reader.GetOrdinal("description")),
            reader.GetDecimal(reader.GetOrdinal("quantity")),
            reader.GetDecimal(reader.GetOrdinal("unit_price")) );
    }

}
