using AMartinezTech.Application.Module.Items.Category.Interfaces;
using AMartinezTech.Domain.Module.Items;
using AMartinezTech.Domain.Utils.Exceptions;
using AMartinezTech.Infrastucture.SqlServer.Utils.Exceptions;
using AMartinezTech.Infrastucture.SqlServer.Utils.Persistence;
using Microsoft.Data.SqlClient;

namespace AMartinezTech.Infrastucture.SqlServer.Module.Items.Category;

public class ItemCategoryWriteRepository(string connectionString) : AdoRepositoryBase(connectionString), IItemCategoryWriteRepository
{
    public async Task CreateAsync(ItemCategoryEntity entity)
    {
        try
        {
            using var conn = GetConnection();
            await conn.OpenAsync();


            var sql = @"INSERT INTO item_categories 
                        (id, name, is_actived)
                        VALUES(@id, @name, @is_actived)";

            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", entity.Id);
            cmd.Parameters.AddWithValue("@name", entity.Name);
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

    public async Task UpdateAsync(ItemCategoryEntity entity)
    {
        try
        {
            using var conn = GetConnection();
            await conn.OpenAsync();


            var sql = @"UPDATE item_categories SET name=@name, is_actived=@is_actived WHERE id = @id ";

            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", entity.Id);
            cmd.Parameters.AddWithValue("@name", entity.Name);
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
