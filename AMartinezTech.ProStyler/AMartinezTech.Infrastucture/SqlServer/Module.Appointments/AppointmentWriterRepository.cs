using AMartinezTech.Application.Module.Appointments.Interfaces;
using AMartinezTech.Domain.Module.Appointments;
using AMartinezTech.Domain.Utils.Exceptions;
using AMartinezTech.Infrastucture.SqlServer.Utils.Exceptions;
using AMartinezTech.Infrastucture.SqlServer.Utils.Persistence;
using Microsoft.Data.SqlClient;

namespace AMartinezTech.Infrastucture.SqlServer.Module.Appointments;

public class AppointmentWriterRepository(string connectionString) : AdoRepositoryBase(connectionString), IAppointmentWriteRepository
{
    public async Task CreateAsync(AppointmentEntity entity)
    {
        try
        {
            using var conn = GetConnection();
            await conn.OpenAsync();

            using var transaction = conn.BeginTransaction();

            try
            {
                // Insertar la cita
                var sql = @"INSERT INTO appointments 
                        (id, staff_id, client_id, asigned_time, limit_time, status)
                        VALUES(@id, @staff_id, @client_id, @asigned_time, @limit_time, @status)";

                using var cmd = new SqlCommand(sql, conn, transaction);
                cmd.Parameters.AddWithValue("@id", entity.Id);
                cmd.Parameters.AddWithValue("@staff_id", entity.StaffId);
                cmd.Parameters.AddWithValue("@client_id", entity.ClientId);
                cmd.Parameters.AddWithValue("@asigned_time", entity.AsignedTime);
                cmd.Parameters.AddWithValue("@limit_time", entity.LimitTime);
                cmd.Parameters.AddWithValue("@status", "Pendiente"); 

                await cmd.ExecuteNonQueryAsync();

                // Insertar los servicios asociados
                var sqlService = @"INSERT INTO appointment_services 
                               (appointment_id, service_id, quantity, price)
                               VALUES(@appointment_id, @service_id, @quantity, @price)";

                foreach (var service in entity.Services)
                {
                    using var cmdService = new SqlCommand(sqlService, conn, transaction);
                    cmdService.Parameters.AddWithValue("@appointment_id", entity.Id);
                    cmdService.Parameters.AddWithValue("@service_id", service.ServiceId);
                    cmdService.Parameters.AddWithValue("@quantity", service.Quantity);
                    cmdService.Parameters.AddWithValue("@price", service.Price);

                    await cmdService.ExecuteNonQueryAsync();
                }

                // ✅ Confirmar la transacción
                await transaction.CommitAsync();
            }
            catch
            {
                // ❌ Revertir si algo falla
                await transaction.RollbackAsync();
                throw;
            }
        }
        catch (SqlException ex)
        {
            var message = SqlErrorMapper.Map(ex);
            throw new DatabaseException(message, ex);
        }
        catch (Exception ex)
        {
            throw new DatabaseException($"{ErrorMessages.Get(ErrorType.DataBaseUnknownError)}", ex);
        }
    }


    public async Task UpdateAsync(AppointmentEntity entity)
    {
        try
        {
            using var conn = GetConnection();
            await conn.OpenAsync();

            using var transaction = conn.BeginTransaction();

            try
            {
                // actualiza la cita
                var sql = @"UPDATE appointments SET
                        staff_id = @staff_id, asigned_time = @asigned_time, 
                        limit_time = @limit_time, status = @status WHERE id=@id; DELETE FROM appointment_services WHERE appointment_id=@id;";

                using var cmd = new SqlCommand(sql, conn, transaction);
                cmd.Parameters.AddWithValue("@id", entity.Id);
                cmd.Parameters.AddWithValue("@staff_id", entity.StaffId); 
                cmd.Parameters.AddWithValue("@asigned_time", entity.AsignedTime);
                cmd.Parameters.AddWithValue("@limit_time", entity.LimitTime);
                cmd.Parameters.AddWithValue("@status", "Pendiente"); 

                await cmd.ExecuteNonQueryAsync();

                // Insertar los servicios asociados
                var sqlService = @"INSERT INTO appointment_services 
                               (appointment_id, service_id, quantity, price)
                               VALUES(@appointment_id, @service_id, @quantity, @price)";

                foreach (var service in entity.Services)
                {
                    using var cmdService = new SqlCommand(sqlService, conn, transaction);
                    cmdService.Parameters.AddWithValue("@appointment_id", entity.Id);
                    cmdService.Parameters.AddWithValue("@service_id", service.ServiceId);
                    cmdService.Parameters.AddWithValue("@quantity", service.Quantity);
                    cmdService.Parameters.AddWithValue("@price", service.Price);

                    await cmdService.ExecuteNonQueryAsync();
                }

                // ✅ Confirmar la transacción
                await transaction.CommitAsync();
            }
            catch
            {
                // ❌ Revertir si algo falla
                await transaction.RollbackAsync();
                throw;
            }
        }
        catch (SqlException ex)
        {
            var message = SqlErrorMapper.Map(ex);
            throw new DatabaseException(message, ex);
        }
        catch (Exception ex)
        {
            throw new DatabaseException($"{ErrorMessages.Get(ErrorType.DataBaseUnknownError)}", ex);
        }
    }
}
