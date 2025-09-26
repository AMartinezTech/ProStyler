using AMartinezTech.Application.Module.Items.Interfaces;
using AMartinezTech.Domain.Module.Items;
using AMartinezTech.Domain.Utils.Exceptions;
using AMartinezTech.Infrastucture.SqlServer.Utils.Exceptions;
using AMartinezTech.Infrastucture.SqlServer.Utils.Persistence;
using Microsoft.Data.SqlClient;

namespace AMartinezTech.Infrastucture.SqlServer.Module.Items;

public class ItemWriteRepository(string connectionString) : AdoRepositoryBase(connectionString), IItemWriteRepository
{
    public async Task CreateAsync(ItemEntity entity)
    {
        try
        {
            using var conn = GetConnection();
            await conn.OpenAsync();


            var sql = @"INSERT INTO items 
                        (id,
                        item_type,
                        category_id, 
                        name,
                        price,
                        stock,
                        generates_commission,
                        is_actived)
                        VALUES(@id,
                        @item_type,
                        @category_id, 
                        @name,
                        @price,
                        @stock,
                        @generates_commission,
                        @is_actived))";

            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", entity.Id);
            cmd.Parameters.AddWithValue("@item_type", entity.ItemType);
            cmd.Parameters.AddWithValue("@category_id", entity.CategoryId);
            cmd.Parameters.AddWithValue("@name", entity.Name);
            cmd.Parameters.AddWithValue("@price", entity.Price);
            cmd.Parameters.AddWithValue("@stock", entity.Stock);
            cmd.Parameters.AddWithValue("@generates_commission", entity.GeneratesCommission);
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

    public async Task UpdateAsync(ItemEntity entity)
    {
        try
        {
            using var conn = GetConnection();
            await conn.OpenAsync();


            var sql = @"UPDATE items SET 
                        item_type=@item_type,
                        category_id=@category_id, 
                        name=@name,
                        price=@price,
                        stock=@stock,
                        generates_commission=@generates_commission,
                        is_actived=@is_actived WHERE id=@id";

            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", entity.Id);
            cmd.Parameters.AddWithValue("@item_type", entity.ItemType);
            cmd.Parameters.AddWithValue("@category_id", entity.CategoryId);
            cmd.Parameters.AddWithValue("@name", entity.Name);
            cmd.Parameters.AddWithValue("@price", entity.Price);
            cmd.Parameters.AddWithValue("@stock", entity.Stock);
            cmd.Parameters.AddWithValue("@generates_commission", entity.GeneratesCommission);
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
