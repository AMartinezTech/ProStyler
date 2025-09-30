using AMartinezTech.Application.Module.Administration.Settings.Interfaces;
using AMartinezTech.Domain.Module.Administration;
using AMartinezTech.Domain.Utils;
using AMartinezTech.Infrastucture.SqlServer.Utils.Persistence;
using Microsoft.Data.SqlClient;

namespace AMartinezTech.Infrastucture.SqlServer.Module.Administration.Settings;

public class SettingReadRepository(string connectionString) : AdoRepositoryBase(connectionString), ISettingReadRepository
{
    public async Task<PageResult<SettingEntity>> PaginationAsync(int pageNumber, int pageSize, bool? isActived)
    {
        try
        {


            var result = new List<SettingEntity>();
            int totalRecords = 0;

            using (var conn = GetConnection())
            {
                await conn.OpenAsync();

                // 1️ Contar total de registros
                var countSql = @"SELECT COUNT(*) FROM settings WHERE 1=1";

                using var countCmd = new SqlCommand(countSql, conn);

                totalRecords = Convert.ToInt32(await countCmd.ExecuteScalarAsync());


                // 2️ Traer página
                var sql = @"SELECT id, company_name, line1, line2, line3, invoice_note, invoice_print_name, invoice_print_type
                        FROM settings
                        WHERE 1=1";

                sql += @" ORDER BY created_at
                  OFFSET @offset ROWS 
                  FETCH NEXT @pageSize ROWS ONLY;";

                using var cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@offset", (pageNumber - 1) * pageSize);
                cmd.Parameters.AddWithValue("@pageSize", pageSize);

                using var reader = await cmd.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                    result.Add(MapToSetting.ToEntity(reader));
            }

            return new PageResult<SettingEntity>(totalRecords, pageSize, result);
        }
        catch (SqlException ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
