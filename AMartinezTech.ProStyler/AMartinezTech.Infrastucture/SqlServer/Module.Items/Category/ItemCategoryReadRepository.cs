using AMartinezTech.Application.Module.Items.Category.Interfaces; 
using AMartinezTech.Domain.Module.Items;
using AMartinezTech.Domain.Utils.Exceptions;
using AMartinezTech.Infrastucture.SqlServer.Utils.Exceptions;
using AMartinezTech.Infrastucture.SqlServer.Utils.Persistence;
using Microsoft.Data.SqlClient;

namespace AMartinezTech.Infrastucture.SqlServer.Module.Items.Category;

public class ItemCategoryReadRepository(string connectionString) : AdoRepositoryBase(connectionString), IItemCategoryReadRepository
{
    public async Task<IReadOnlyList<ItemCategoryEntity>> FilterAsync(string? filterStr, bool? isActived)
    {
        var result = new List<ItemCategoryEntity>();
        using (var conn = GetConnection())
        {
            await conn.OpenAsync();

            // Base query
            var sql = @"SELECT TOP 100 * FROM item_categories WHERE 1=1";

            if (!string.IsNullOrWhiteSpace(filterStr))
                sql += " AND (name LIKE @filter )";

            using var cmd = new SqlCommand(sql, conn);



            if (!string.IsNullOrWhiteSpace(filterStr))
                cmd.Parameters.AddWithValue("@filter", $"%{filterStr}%");

            using var reader = cmd.ExecuteReader();
            while (await reader.ReadAsync())
                result.Add(MapToItemCategory.ToEntity(reader));
        }
        return result;
    }

    public async Task<ItemCategoryEntity> GetByIdAsync(Guid id)
    {
        try
        {
            ItemCategoryEntity? entity = null;
            using var conn = GetConnection();
            await conn.OpenAsync();

            var sql = @"SELECT 
                            id,
                            name,
                            is_active
                        FROM item_categories
                        WHERE id=@id";
            using var cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@id", id);

            using var reader = await cmd.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                entity = MapToItemCategory.ToEntity(reader);
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
