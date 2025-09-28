using AMartinezTech.Application.Module.Reports;
using AMartinezTech.Domain.Module.Billing;
using AMartinezTech.Infrastucture.SqlServer.Module.Billing;
using AMartinezTech.Infrastucture.SqlServer.Utils.Persistence;
using Microsoft.Data.SqlClient;

namespace AMartinezTech.Infrastucture.SqlServer.Module.Report;

public class ReportSaleService(string connectionString) : AdoRepositoryBase(connectionString), IReportSalesService
{
    public async Task<IEnumerable<InvoiceEntity>> ReportServiceAsync(DateTime initialDate, DateTime endDate)
    {
        var result = new List<InvoiceEntity>();

        using var conn = GetConnection();

        await conn.OpenAsync();


        var sqlHeader = @"SELECT TOP 100 i.id, i.client_id, c.name AS client_name,
                          i.staff_id, s.name AS staff_name,
                          i.created_at, i.status
                          FROM invoices i
                          INNER JOIN clients c ON i.client_id = c.id
                          INNER JOIN staff s ON i.staff_id = s.id
                          WHERE created_at BETWEEN @startDate AND @endDate
                          AND status != @status";
 

        var invoiceIds = new List<Guid>(); // para guardar los id de invoiceEntity
        using var cmd = new SqlCommand(sqlHeader, conn);

        cmd.Parameters.AddWithValue("@startDate", initialDate);
        cmd.Parameters.AddWithValue("@endDate", endDate);
        cmd.Parameters.AddWithValue("@status1", "Anulada"); 

        using var reader = await cmd.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            var invoice = MapToInvoice.Header(reader); // Mapea a invoice entity
            result.Add(invoice);
            invoiceIds.Add(invoice.Id); // agrega los id de invoiceEntity para usarlos más adelante

        }

        // 3️ Traer detalles (solo de los invoices seleccionados)
        if (invoiceIds.Count > 0) // Si tengo id de invoiceEntity, entonce  bscamos los detalles
        {
            var idsParam = string.Join(",", invoiceIds.Select((id, index) => $"@id{index}")); // unes los id separados por comas, para usarlos en la consulta sql del detalle de cada invoice

            var sqlDetail = $@"SELECT id, invoice_id, item_type, description, quantity, unit_price
                               FROM invoice_details
                               WHERE invoice_id IN ({idsParam})";


            using var cmdDetail = new SqlCommand(sqlDetail, conn);

            for (int i = 0; i < invoiceIds.Count; i++) // iteramos para agregar los parametros
                cmdDetail.Parameters.AddWithValue($"@id{i}", invoiceIds[i]);

            using var readerDetail = await cmdDetail.ExecuteReaderAsync();

            while (await readerDetail.ReadAsync())
            {
                var detail = MapToInvoice.Details(readerDetail); // mapeamos a invoiceDetailEntity
                var invoive = result.FirstOrDefault(x => x.Id == detail.InvoiceId); // buscamo cada invoice dentro de result, para asignar el detalle
                invoive?.AddDetail(detail); // asignamos el detalle
            }

        }


        return result;
    }
}
