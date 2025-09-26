using AMartinezTech.Application.Module.Items.Interfaces;
using AMartinezTech.Domain.Module.Appointments;
using AMartinezTech.Domain.Module.Clients;
using AMartinezTech.Domain.Module.Items;
using AMartinezTech.Domain.Utils;
using AMartinezTech.Domain.Utils.Exceptions;
using AMartinezTech.Infrastucture.SqlServer.Module.Appointments;
using AMartinezTech.Infrastucture.SqlServer.Module.Clients;
using AMartinezTech.Infrastucture.SqlServer.Utils.Exceptions;
using AMartinezTech.Infrastucture.SqlServer.Utils.Persistence;
using Microsoft.Data.SqlClient;

namespace AMartinezTech.Infrastucture.SqlServer.Module.Items;

public class ItemReadRepository(string connectionString) : AdoRepositoryBase(connectionString), IItemReadRepository
{
    public async Task<IReadOnlyList<ItemEntity>> FilterAsync(string? filterStr, bool? isActived)
    {
        var result = new List<ItemEntity>();
        using (var conn = GetConnection())
        {
            await conn.OpenAsync();

            // Base query
            var sql = @"SELECT TOP 100 * FROM items WHERE 1=1";

            if (!string.IsNullOrWhiteSpace(filterStr))
                sql += " AND (name LIKE @filter )";

            using var cmd = new SqlCommand(sql, conn);



            if (!string.IsNullOrWhiteSpace(filterStr))
                cmd.Parameters.AddWithValue("@filter", $"%{filterStr}%");

            using var reader = cmd.ExecuteReader();
            
            while (await reader.ReadAsync())
                result.Add(MapToItem.ToEntity(reader));
        }
        return result;
    }

    public async Task<ItemEntity> GetByIdAsync(Guid id)
    {
        try
        {
            ItemEntity? entity = null;
            using var conn = GetConnection();
            await conn.OpenAsync();

            var sql = @"SELECT 
                            i.id,
                            i.item_type,
                            i.category_id,
                            c.name AS category_name,
                            i.name,
                            i.price,
                            i.stock,
                            i.generates_commission,
                            i.is_actived
                        FROM items i
                        INNER JOIN item_categories c ON a.category_id = c.id
                        WHERE id=@id";

           
            using var cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@id", id);

            using var reader = await cmd.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                entity = MapToItem.ToEntity(reader);
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

    public async Task<PageResult<ItemEntity>> PaginationAsync(int pageNumber, int pageSize, bool? isActived)
    {
        var result = new List<ItemEntity>();
        int totalRecords = 0;

        using (var conn = GetConnection())
        {
            await conn.OpenAsync();

            // 1️ Contar total de registros
            var countSql = @"SELECT COUNT(*) FROM items WHERE 1=1";

            if (isActived.HasValue)
                countSql += " AND is_actived=@is_actived";

            using var countCmd = new SqlCommand(countSql, conn);

            if (isActived.HasValue)
                countCmd.Parameters.AddWithValue("@is_actived", isActived); 


            totalRecords = Convert.ToInt32(await countCmd.ExecuteScalarAsync());


            // 2️ Traer página
            var sql = @"SELECT 
                            i.id,
                            i.item_type,
                            i.category_id,
                            c.name AS category_name,
                            i.name,
                            i.price,
                            i.stock,
                            i.generates_commission,
                            i.is_actived
                        FROM items i
                        INNER JOIN item_categories c ON a.category_id = c.id
                        WHERE 1=1";

            if (isActived.HasValue)
                sql += " AND is_actived=@is_actived";

            sql += @" ORDER BY created_at
                  OFFSET @offset ROWS 
                  FETCH NEXT @pageSize ROWS ONLY;";

            using var cmd = new SqlCommand(sql, conn);


            if (isActived.HasValue)
                cmd.Parameters.AddWithValue("@is_actived", isActived);

            cmd.Parameters.AddWithValue("@offset", (pageNumber - 1) * pageSize);
            cmd.Parameters.AddWithValue("@pageSize", pageSize);

            using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
                result.Add(MapToItem.ToEntity(reader));
        }

        return new PageResult<ItemEntity>(totalRecords, pageSize, result);
    }
}
