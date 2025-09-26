using AMartinezTech.Application.Module.Clients.Interfaces;
using AMartinezTech.Domain.Module.Appointments;
using AMartinezTech.Domain.Module.Clients;
using AMartinezTech.Domain.Utils.Exceptions;
using AMartinezTech.Infrastucture.SqlServer.Module.Appointments;
using AMartinezTech.Infrastucture.SqlServer.Utils.Exceptions;
using AMartinezTech.Infrastucture.SqlServer.Utils.Persistence;
using Microsoft.Data.SqlClient;

namespace AMartinezTech.Infrastucture.SqlServer.Module.Clients;

public class ClientReadRepository(string connectionString) : AdoRepositoryBase(connectionString), IClientReadRepository
{
    public async Task<IReadOnlyList<ClientEntity>> FilterAsync(string? filterStr, bool? isActived)
    {
        var result = new List<ClientEntity>();
        using (var conn = GetConnection())
        {
            await conn.OpenAsync();

            // Base query
            var sql = @"SELECT TOP 100 * FROM clients WHERE 1=1";
             
            if (!string.IsNullOrWhiteSpace(filterStr))
                sql += " AND (name LIKE @filter OR phone LIKE @filter OR email LIKE @filter)";

            using var cmd = new SqlCommand(sql, conn);

             

            if (!string.IsNullOrWhiteSpace(filterStr))
                cmd.Parameters.AddWithValue("@filter", $"%{filterStr}%");

            using var reader = cmd.ExecuteReader();
            while (await reader.ReadAsync())
                result.Add(MapToClient.ToEntity(reader));
        }
        return result;
    }

    public async Task<ClientEntity> GetByIdAsync(Guid id)
    {
        try
        {
            ClientEntity? entity = null;
            using var conn = GetConnection();
            await conn.OpenAsync();

            var sql = @"SELECT 
                            id,
                            name,
                            phone,
                            email,
                            created_at
                        FROM clients
                        WHERE id=@id";
            using var cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@id", id);

            using var reader = await cmd.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                entity = MapToClient.ToEntity(reader);
            }

            if (entity == null) throw new DatabaseException($"{ErrorMessages.Get(ErrorType.RecordDoesDotExist)}"); ;


            return entity;


        }
        catch (SqlException ex)
        {
            var messaje = SqlErrorMapper.Map(ex);
            throw new DatabaseException(messaje);
        }
        catch (Exception ex) { throw new DatabaseException($"{ErrorMessages.Get(ErrorType.DataBaseUnknownError)}", ex); }
    }
}
