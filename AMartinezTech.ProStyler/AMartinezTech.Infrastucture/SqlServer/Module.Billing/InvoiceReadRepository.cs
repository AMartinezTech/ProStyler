using AMartinezTech.Application.Module.Billing.Interfaces;
using AMartinezTech.Domain.Module.Billing;
using AMartinezTech.Domain.Utils;
using AMartinezTech.Domain.Utils.Exceptions;
using AMartinezTech.Infrastucture.SqlServer.Utils.Exceptions;
using AMartinezTech.Infrastucture.SqlServer.Utils.Persistence;
using Microsoft.Data.SqlClient;

namespace AMartinezTech.Infrastucture.SqlServer.Module.Billing;

public class InvoiceReadRepository(string connectionString) : AdoRepositoryBase(connectionString), IInvoiceReadRepository
{
    public async Task<IReadOnlyList<InvoiceEntity>> FilterAsync(string? filterStr, bool? isActived)
    {
        var result = new List<InvoiceEntity>();

        using var conn = GetConnection();

        await conn.OpenAsync();


        var sqlHeader = @"SELECT TOP 100 i.id, i.client_id, c.name AS client_name,
                          i.staff_id, s.name AS staff_name,
                          i.created_at, i.status
                          FROM invoices i
                          INNER JOIN clients c ON i.client_id = c.id
                          INNER JOIN staff s   ON i.staff_id = s.id
                          WHERE i.status != @status ";

        if (!string.IsNullOrWhiteSpace(filterStr))
            sqlHeader += " AND (c.name LIKE @filter OR s.name LIKE @filter ORDER BY i.created_at;)";

        var invoiceIds = new List<Guid>(); // para guardar los id de invoiceEntity
        using var cmd = new SqlCommand(sqlHeader, conn);

        if (!string.IsNullOrWhiteSpace(filterStr))
            cmd.Parameters.AddWithValue("@filter", $"%{filterStr}%");

        cmd.Parameters.AddWithValue("@status", "Anulada");

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

    public async Task<InvoiceEntity> GetByIdAsync(Guid id)
    {
        try
        {
            InvoiceEntity? entity = null;
            using var conn = GetConnection();
            await conn.OpenAsync();

            var sql = @"SELECT 
                            i.id,
                            i.client_id,
                            c.name AS client_name,
                            i.staff_id,
                            s.name AS staff_name,
                            i.created_at,
                            i.status
                        FROM invoices i
                        INNER JOIN clients c ON a.client_id = c.id
                        INNER JOIN staff s   ON a.staff_id = s.id
                        WHERE id=@id";
            using var cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@id", id);

            using var reader = await cmd.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                entity = MapToInvoice.Header(reader);
            }

            if (entity == null) throw new DatabaseException($"{ErrorMessages.Get(ErrorType.RecordDoesDotExist)}"); ;

            var queryServices = @"SELECT 
                                    id,
                                    invoice_id,
                                    item_type,
                                    description,
                                    quantity,
                                    unit_price 
                              FROM invoice_details
                              WHERE invoice_id = @id";

            using (var command = new SqlCommand(queryServices, conn))
            {
                command.Parameters.AddWithValue("@id", id);

                using var readerService = await command.ExecuteReaderAsync();
                while (await readerService.ReadAsync())
                {
                    var service = MapToInvoice.Details(readerService);
                    entity.AddDetail(service);
                }
            }

            return entity;


        }
        catch (SqlException ex)
        {
            var messaje = SqlErrorMapper.Map(ex);
            throw new DatabaseException(messaje);
        }
        catch (Exception ex) { throw new DatabaseException($"{ErrorMessages.Get(ErrorType.DataBaseUnknownError)}", ex); }
    }

    public async Task<PageResult<InvoiceEntity>> PaginationAsync(int pageNumber, int pageSize, bool? isActived)
    {
        var result = new List<InvoiceEntity>();
        int totalRecords = 0;

        using (var conn = GetConnection())
        {
            await conn.OpenAsync();

            // 1️ Contar total de registros
            var countSql = @"SELECT COUNT(*) FROM invoices WHERE status != @status";

            using var countCmd = new SqlCommand(countSql, conn);

            countCmd.Parameters.AddWithValue("@status", "Anulada");
            totalRecords = Convert.ToInt32(await countCmd.ExecuteScalarAsync());


            // 1. Traes los headers con paginación
            var sqlHeader = @"SELECT i.id, i.client_id, c.name AS client_name,
                         i.staff_id, s.name AS staff_name,
                         i.created_at, i.status
                  FROM invoices i
                  INNER JOIN clients c ON i.client_id = c.id
                  INNER JOIN staff s   ON i.staff_id = s.id
                  WHERE i.status != @status
                  ORDER BY i.created_at
                  OFFSET @offset ROWS FETCH NEXT @pageSize ROWS ONLY;";


            var invoiceIds = new List<Guid>(); // para guardar los id de invoiceEntity
            using var cmd = new SqlCommand(sqlHeader, conn);

            cmd.Parameters.AddWithValue("@status", "Anulada");


            cmd.Parameters.AddWithValue("@offset", (pageNumber - 1) * pageSize);
            cmd.Parameters.AddWithValue("@pageSize", pageSize);

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
        }

        return new PageResult<InvoiceEntity>(totalRecords, pageSize, result);
    }
}
