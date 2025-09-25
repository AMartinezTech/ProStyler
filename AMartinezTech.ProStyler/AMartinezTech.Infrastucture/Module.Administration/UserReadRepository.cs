using AMartinezTech.Application.Module.Administration.Interfaces;
using AMartinezTech.Domain.Module.Administration;
using AMartinezTech.Infrastucture.Utils.SqlServer.Persistence;
using Microsoft.Data.SqlClient;

namespace AMartinezTech.Infrastucture.Module.Administration;

public class UserReadRepository(string connectionString) : AdoRepositoryBase(connectionString), IUserReadRepository
{
    public async Task<IReadOnlyList<UserEntity>> FilterAsync(string? filterStr, bool? isActived)
    {
        var result = new List<UserEntity>();
        using (var conn = GetConnection())
        {
            await conn.OpenAsync();

            // Base query
            var sql = @"SELECT TOP 100 * FROM users WHERE 1=1";

            if (isActived.HasValue)
                sql += " AND is_actived=@is_actived";

            if (!string.IsNullOrWhiteSpace(filterStr))
                sql += " AND (user_name LIKE @filter OR name LIKE @filter)";

            using var cmd = new SqlCommand(sql, conn);

            if (isActived.HasValue)
                cmd.Parameters.AddWithValue("@is_actived", isActived);

            if (!string.IsNullOrWhiteSpace(filterStr))
                cmd.Parameters.AddWithValue("@filter", $"%{filterStr}%");

            using var reader = cmd.ExecuteReader();
            while (await reader.ReadAsync())
                result.Add(MapToUser.ToEntity(reader));
        }
        return result;
    }

    public Task<UserEntity> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<UserEntity> LoginAsync(string userName, string password)
    {
        throw new NotImplementedException();
    }
}
