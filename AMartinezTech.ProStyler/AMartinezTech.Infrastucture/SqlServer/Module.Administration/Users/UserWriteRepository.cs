using AMartinezTech.Application.Module.Administration.Users.Interfaces;
using AMartinezTech.Domain.Module.Administration;
using AMartinezTech.Domain.Utils.Exceptions;
using AMartinezTech.Infrastucture.SqlServer.Utils.Exceptions;
using AMartinezTech.Infrastucture.SqlServer.Utils.Persistence;
using Microsoft.Data.SqlClient;

namespace AMartinezTech.Infrastucture.SqlServer.Module.Administration.Users;

public class UserWriteRepository(string connectionString) : AdoRepositoryBase(connectionString), IUserWriteRepository
{
    public async Task CreateAsync(UserEntity entity)
    {
        try
        {

            using var conn = GetConnection();
            await conn.OpenAsync();

            using var cmd = new SqlCommand("INSERT INTO users (id,name,user_name,password,rol,is_actived) VALUES(@id,@name,@user_name,@password,@rol,@is_actived)", conn);

            cmd.Parameters.AddWithValue("@id",entity.Id);
            cmd.Parameters.AddWithValue("@name", entity.Name.Value);
            cmd.Parameters.AddWithValue("@user_name", entity.UserName.Value);
            cmd.Parameters.AddWithValue("@password", entity.PasswordHash.Hash);
            cmd.Parameters.AddWithValue("@rol", entity.Rol.Type);
            cmd.Parameters.AddWithValue("@is_actived", entity.IsActived);
            
            await cmd.ExecuteNonQueryAsync();
        }
        catch (SqlException ex)
        {
            var messaje = SqlErrorMapper.Map(ex);
            throw new DatabaseException(messaje);
        }
        catch (Exception ex) { throw new DatabaseException($"{ErrorMessages.Get(ErrorType.DataBaseUnknownError)}", ex); }

    }

    public async Task UpdateAsync(UserEntity entity)
    {
        try
        {

            using var conn = GetConnection();
            await conn.OpenAsync();

            using var cmd = new SqlCommand("UPDATE users SET name=@name,rol=@rol,is_actived=@is_actived WHERE id=@id", conn);

            cmd.Parameters.AddWithValue("@id", entity.Id);
            cmd.Parameters.AddWithValue("@name", entity.Name.Value);
            cmd.Parameters.AddWithValue("@rol", entity.Rol.Type);
            cmd.Parameters.AddWithValue("@is_actived", entity.IsActived);

            await cmd.ExecuteNonQueryAsync();
        }
        catch (SqlException ex)
        {
            var messaje = SqlErrorMapper.Map(ex);
            throw new DatabaseException(messaje);
        }
        catch (Exception ex) { throw new DatabaseException($"{ErrorMessages.Get(ErrorType.DataBaseUnknownError)}", ex); }
    }
}
