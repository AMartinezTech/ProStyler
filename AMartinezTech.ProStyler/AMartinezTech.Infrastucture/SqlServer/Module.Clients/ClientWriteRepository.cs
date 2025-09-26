using AMartinezTech.Application.Module.Clients.Interfaces;
using AMartinezTech.Domain.Module.Clients;
using AMartinezTech.Domain.Utils.Exceptions;
using AMartinezTech.Infrastucture.SqlServer.Utils.Exceptions;
using AMartinezTech.Infrastucture.SqlServer.Utils.Persistence;
using Microsoft.Data.SqlClient; 

namespace AMartinezTech.Infrastucture.SqlServer.Module.Clients;

public class ClientWriteRepository(string connectionString) : AdoRepositoryBase(connectionString), IClientWriteRepository
{
    public async Task CreateAsync(ClientEntity entity)
    {
        try
        {
            using var conn = GetConnection();
            await conn.OpenAsync();

            
            var sql = @"INSERT INTO clients 
                        (id, name, phone, email)
                        VALUES(@id, @name, @phone, @email)";

            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", entity.Id);
            cmd.Parameters.AddWithValue("@name", entity.Name);
            cmd.Parameters.AddWithValue("@phone", entity.Phone);
            cmd.Parameters.AddWithValue("@email", entity.Email); 

           
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

    public async Task UpdateAsync(ClientEntity entity)
    {
        try
        {
            using var conn = GetConnection();
            await conn.OpenAsync();


            var sql = @"UPDATE clients SET  name = @name, phone = @phone, email = @email WHERE id = @id ";

            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", entity.Id);
            cmd.Parameters.AddWithValue("@name", entity.Name);
            cmd.Parameters.AddWithValue("@phone", entity.Phone);
            cmd.Parameters.AddWithValue("@email", entity.Email);


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
