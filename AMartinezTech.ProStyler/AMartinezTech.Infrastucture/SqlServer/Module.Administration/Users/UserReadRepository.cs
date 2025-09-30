using AMartinezTech.Application.Module.Administration.Users.Interfaces;
using AMartinezTech.Domain.Module.Administration;
using AMartinezTech.Domain.Module.Items;
using AMartinezTech.Domain.Utils.Exceptions;
using AMartinezTech.Infrastucture.SqlServer.Module.Items;
using AMartinezTech.Infrastucture.SqlServer.Utils.Exceptions;
using AMartinezTech.Infrastucture.SqlServer.Utils.Persistence;
using Microsoft.Data.SqlClient;

namespace AMartinezTech.Infrastucture.SqlServer.Module.Administration.Users;

public class UserReadRepository(string connectionString) : AdoRepositoryBase(connectionString), IUserReadRepository
{
    public async Task<IReadOnlyList<UserEntity>> FilterAsync(string? filterStr, bool? isActived)
    {
        var result = new List<UserEntity>();
        using (var conn = GetConnection())
        {
            await conn.OpenAsync();

            // Base query
            var sql = @"SELECT TOP 100 id, name, user_name, password, rol, is_actived FROM users WHERE 1=1";

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

    public async Task<UserEntity> GetByIdAsync(Guid id)
    {
        try
        {
            UserEntity? entity = null;
            using var conn = GetConnection();
            await conn.OpenAsync();

            var sql = @"SELECT  id, name, user_name, password, rol, is_actived
                        FROM users WHERE id=@id";


            using var cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@id", id);

            using var reader = await cmd.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                entity = MapToUser.ToEntity(reader);
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

    public async Task<UserEntity> LoginAsync(string userName, string password)
    {
        try
        {
            UserEntity? entity = null;
            using var conn = GetConnection();
            await conn.OpenAsync();

            var sql = @"SELECT id, name, user_name, password, rol, is_actived
                    FROM users 
                    WHERE user_name = @user_name";

            using var cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@user_name", userName);

            using var reader = await cmd.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                entity = MapToUser.ToEntity(reader);
            } 

            if (entity == null) throw new Exception($"{ErrorMessages.Get(ErrorType.InvalidCredentials)} - NoExistUser"); 
            
            if (!entity.IsActived) throw new Exception($"{ErrorMessages.Get(ErrorType.InvalidCredentials)} - NoActivedUse");

            if (!entity.PasswordHash.Verify(password)) throw new Exception($"{ErrorMessages.Get(ErrorType.InvalidCredentials)} - PassNotMach");

            return entity;

        }
        catch (SqlException ex)
        {
            var messaje = SqlErrorMapper.Map(ex);
            throw new DatabaseException(messaje);
        }
        catch (Exception ex) { throw; }
    }
}
