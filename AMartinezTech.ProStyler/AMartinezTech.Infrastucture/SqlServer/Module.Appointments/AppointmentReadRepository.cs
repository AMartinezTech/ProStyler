using AMartinezTech.Application.Module.Appointments.Interfaces;
using AMartinezTech.Domain.Module.Appointments;
using AMartinezTech.Domain.Utils;
using AMartinezTech.Domain.Utils.Exceptions;
using AMartinezTech.Infrastucture.SqlServer.Utils.Exceptions;
using AMartinezTech.Infrastucture.SqlServer.Utils.Persistence;
using Microsoft.Data.SqlClient;
namespace AMartinezTech.Infrastucture.SqlServer.Module.Appointments;

public class AppointmentReadRepository(string connectionString) : AdoRepositoryBase(connectionString), IAppointmentReadRepository
{
    public async Task<ByDateResult<AppointmentEntity>> GetByDateAsync(DateTime initialDate, DateTime endDate, bool? isActived)
    {
        var result = new List<AppointmentEntity>();
         

        using (var conn = GetConnection())
        {
            await conn.OpenAsync();


            var sql = @"SELECT 
                            a.id,
                            a.staff_id,
                            s.name AS staff_name,
                            a.client_id,
                            c.name AS client_name,
                            a.asigned_time,
                            a.limit_time,
                            a.created_at,
                            a.status
                        FROM appointments a
                        INNER JOIN clients c ON a.client_id = c.id
                        INNER JOIN staff s   ON a.staff_id = s.id
                        WHERE created_at BETWEEN @startDate AND @endDate
                        AND status NOT IN (@status1, @status2)";


            using var cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@startDate", initialDate);
            cmd.Parameters.AddWithValue("@endDate", endDate);
            cmd.Parameters.AddWithValue("@status1", "Cancelada");
            cmd.Parameters.AddWithValue("@status2", "Expirada");


            using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
                result.Add(MapToAppointment.ToEntity(reader));
        }

        return new ByDateResult<AppointmentEntity>(initialDate, endDate, result);
    }

    public async Task<AppointmentEntity> GetByIdAsync(Guid id)
    {
        try
        {
            AppointmentEntity? entity = null;
            using var conn = GetConnection();
            await conn.OpenAsync();

            var sql = @"SELECT 
                            a.id,
                            a.staff_id,
                            s.name AS staff_name,
                            a.client_id,
                            c.name AS client_name,
                            a.asigned_time,
                            a.limit_time,
                            a.created_at,
                            a.status
                        FROM appointments a
                        INNER JOIN clients c ON a.client_id = c.id
                        INNER JOIN staff s   ON a.staff_id = s.id
                        WHERE id=@id";
            using var cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@id", id);

            using var reader = await cmd.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                entity = MapToAppointment.ToEntity(reader);
            }

            if (entity == null) throw new DatabaseException($"{ErrorMessages.Get(ErrorType.RecordDoesDotExist)}"); ;

            var queryServices = @"SELECT a.appointment_id, a.service_id, a.quantity, a.quantity, s.name AS service_name 
                              FROM appointment_services a
                              INNER JOIN services a ON a.service_id = s.id 
                              WHERE appointment_id = @id";

            using (var command = new SqlCommand(queryServices, conn))
            {
                command.Parameters.AddWithValue("@id", id);

                using var readerService = await command.ExecuteReaderAsync();
                while (await readerService.ReadAsync())
                {
                    var service = MapToAppointment.ToEntityService(readerService);
                    entity.AddService(service);
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

    public async Task<PageResult<AppointmentEntity>> PaginationAsync(int pageNumber, int pageSize, bool? isActived)
    {
        var result = new List<AppointmentEntity>();
        int totalRecords = 0;

        using (var conn = GetConnection())
        {
            await conn.OpenAsync();

            // 1️ Contar total de registros
            var countSql = @"SELECT COUNT(*) FROM appointments WHERE status NOT IN (@status1, @status2)";

            using (var countCmd = new SqlCommand(countSql, conn))
            {

                countCmd.Parameters.AddWithValue("@status1", "Cancelada");
                countCmd.Parameters.AddWithValue("@status2", "Expirada");


                totalRecords = Convert.ToInt32(await countCmd.ExecuteScalarAsync());
            }

            // 2️ Traer página
            var sql = @"SELECT 
                            a.id,
                            a.staff_id,
                            s.name AS staff_name,
                            a.client_id,
                            c.name AS client_name,
                            a.asigned_time,
                            a.limit_time,
                            a.created_at,
                            a.status
                        FROM appointments a
                        INNER JOIN clients c ON a.client_id = c.id
                        INNER JOIN staff s   ON a.staff_id = s.id
                        WHERE status NOT IN (@status1, @status2)"; 


            sql += @" ORDER BY created_at
                  OFFSET @offset ROWS 
                  FETCH NEXT @pageSize ROWS ONLY;";

            using var cmd = new SqlCommand(sql, conn);


            cmd.Parameters.AddWithValue("@status1", "Cancelada");
            cmd.Parameters.AddWithValue("@status2", "Expirada");

            cmd.Parameters.AddWithValue("@offset", (pageNumber - 1) * pageSize);
            cmd.Parameters.AddWithValue("@pageSize", pageSize);

            using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
                result.Add(MapToAppointment.ToEntity(reader));
        }

        return new PageResult<AppointmentEntity>(totalRecords, pageSize, result);
    }
}
