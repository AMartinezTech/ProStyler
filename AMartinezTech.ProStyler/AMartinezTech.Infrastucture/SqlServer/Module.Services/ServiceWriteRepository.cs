using AMartinezTech.Application.Module.Services.Interfaces;
using AMartinezTech.Domain.Module.Services;
using AMartinezTech.Domain.Utils.Exceptions;
using AMartinezTech.Infrastucture.SqlServer.Utils.Exceptions;
using AMartinezTech.Infrastucture.SqlServer.Utils.Persistence;
using Microsoft.Data.SqlClient;

namespace AMartinezTech.Infrastucture.SqlServer.Module.Services;

public class ServiceWriteRepository(string connectionString) : AdoRepositoryBase(connectionString), IServiceWriteRepository
{
    public async Task CreateAsync(ServiceEntity entity)
    {
        try
        {
            using var conn = GetConnection();
            await conn.OpenAsync();


            var sql = @"INSERT INTO services 
                        (id, name, price, working_time, note, is_actived)
                        VALUES(@id, @name, @price, @working_time, @note, @is_actived)";

            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", entity.Id);
            cmd.Parameters.AddWithValue("@name", entity.Name);
            cmd.Parameters.AddWithValue("@price", entity.Price);
            cmd.Parameters.AddWithValue("@working_time", entity.WorkingTime);
            cmd.Parameters.AddWithValue("@note", entity.Note);
            cmd.Parameters.AddWithValue("@is_actived", entity.IsActived);


            await cmd.ExecuteNonQueryAsync();
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

    public async Task UpdateAsync(ServiceEntity entity)
    {
        try
        {
            using var conn = GetConnection();
            await conn.OpenAsync();


            var sql = @"UPDATE clients SET name=@name, price=@price, working_time=@working_time, note=@note, is_actived=@is_actived WHERE id = @id ";

            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", entity.Id);
            cmd.Parameters.AddWithValue("@name", entity.Name);
            cmd.Parameters.AddWithValue("@price", entity.Price);
            cmd.Parameters.AddWithValue("@working_time", entity.WorkingTime);
            cmd.Parameters.AddWithValue("@note", entity.Note);
            cmd.Parameters.AddWithValue("@is_actived", entity.IsActived);


            await cmd.ExecuteNonQueryAsync();
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
