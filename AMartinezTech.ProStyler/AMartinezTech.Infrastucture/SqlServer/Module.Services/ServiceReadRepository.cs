using AMartinezTech.Application.Module.Services.Interfaces;
using AMartinezTech.Domain.Module.Clients;
using AMartinezTech.Domain.Module.Services;
using AMartinezTech.Domain.Utils.Exceptions;
using AMartinezTech.Infrastucture.SqlServer.Module.Clients;
using AMartinezTech.Infrastucture.SqlServer.Utils.Exceptions;
using AMartinezTech.Infrastucture.SqlServer.Utils.Persistence;
using Microsoft.Data.SqlClient;

namespace AMartinezTech.Infrastucture.SqlServer.Module.Services;

public class ServiceReadRepository(string connectionString) : AdoRepositoryBase(connectionString), IServiceReadRepository
{
    public async Task<IReadOnlyList<ServiceEntity>> FilterAsync(string? filterStr, bool? isActived)
    {
        var result = new List<ServiceEntity>();
        using (var conn = GetConnection())
        {
            await conn.OpenAsync();

            // Base query
            var sql = @"SELECT TOP 100 * FROM services WHERE 1=1";

            if (!string.IsNullOrWhiteSpace(filterStr))
                sql += " AND (name LIKE @filter)";

            if (isActived.HasValue)
                sql += " AND is_actived=@is_actived";

            using var cmd = new SqlCommand(sql, conn);


            if (!string.IsNullOrWhiteSpace(filterStr))
                cmd.Parameters.AddWithValue("@filter", $"%{filterStr}%");

            if (isActived.HasValue)
                cmd.Parameters.AddWithValue("@is_actived", isActived);


            using var reader = cmd.ExecuteReader();
            while (await reader.ReadAsync())
                result.Add(MapToService.ToEntity(reader));
        }
        return result;
    }

    public async Task<ServiceEntity> GetByIdAsync(Guid id)
    {
        try
        {
            ServiceEntity? entity = null;
            using var conn = GetConnection();
            await conn.OpenAsync();

            var sql = @"SELECT 
                            id,
                            name,
                            price,
                            working_time,
                            note,
                            is_actived
                        FROM services
                        WHERE id=@id";
            using var cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@id", id);

            using var reader = await cmd.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                entity = MapToService.ToEntity(reader);
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
