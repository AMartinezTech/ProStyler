using AMartinezTech.Application.Module.Staff.Interfaces;
using AMartinezTech.Domain.Module.Clients;
using AMartinezTech.Domain.Module.Staff;
using AMartinezTech.Domain.Utils.Exceptions;
using AMartinezTech.Infrastucture.SqlServer.Module.Clients;
using AMartinezTech.Infrastucture.SqlServer.Utils.Exceptions;
using AMartinezTech.Infrastucture.SqlServer.Utils.Persistence;
using Microsoft.Data.SqlClient;

namespace AMartinezTech.Infrastucture.SqlServer.Module.Staff;

public class StaffReadRepository(string connectionString) : AdoRepositoryBase(connectionString), IStaffReadRepository
{
    public async Task<IReadOnlyList<StaffEntity>> FilterAsync(string? filterStr, bool? isActived)
    {
        var result = new List<StaffEntity>();
        using (var conn = GetConnection())
        {
            await conn.OpenAsync();

            // Base query
            var sql = @"SELECT TOP 100 * FROM staffs WHERE 1=1";

            if (!string.IsNullOrWhiteSpace(filterStr))
                sql += " AND (name LIKE @filter OR phone LIKE @filter)";

            using var cmd = new SqlCommand(sql, conn);



            if (!string.IsNullOrWhiteSpace(filterStr))
                cmd.Parameters.AddWithValue("@filter", $"%{filterStr}%");

            using var reader = cmd.ExecuteReader();
            while (await reader.ReadAsync())
                result.Add(MapToStaff.ToEntity(reader));
        }
        return result;
    }

    public async Task<StaffEntity> GetByIdAsync(Guid id)
    {
        try
        {
            StaffEntity? entity = null;
            using var conn = GetConnection();
            await conn.OpenAsync();

            var sql = @"SELECT id, name, phone, specialties, is_actived, commision_fee_by_product, commision_fee_by_service 
                        FROM staffs
                        WHERE id=@id";
            using var cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@id", id);

            using var reader = await cmd.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                entity = MapToStaff.ToEntity(reader);
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
