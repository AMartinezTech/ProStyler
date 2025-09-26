using AMartinezTech.Application.Module.Staff.Interfaces;
using AMartinezTech.Domain.Module.Staff;
using AMartinezTech.Domain.Utils.Exceptions;
using AMartinezTech.Infrastucture.SqlServer.Utils.Exceptions;
using AMartinezTech.Infrastucture.SqlServer.Utils.Persistence;
using Microsoft.Data.SqlClient;

namespace AMartinezTech.Infrastucture.SqlServer.Module.Staff;

public class StaffWriteRepository(string connectionString) : AdoRepositoryBase(connectionString), IStaffWriteRepository
{
    public async Task CreateAsync(StaffEntity entity)
    {
        try
        {
            using var conn = GetConnection();
            await conn.OpenAsync();


            var sql = @"INSERT INTO staffs 
                        (id, name, phone, specialties, is_actived, commision_fee_by_product, commision_fee_by_service) VALUES(@id, @name, @phone, @specialties, @is_actived, @commision_fee_by_product, @commision_fee_by_service)";

            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", entity.Id);
            cmd.Parameters.AddWithValue("@name", entity.Name);
            cmd.Parameters.AddWithValue("@phone", entity.Phone);
            cmd.Parameters.AddWithValue("@specialties", entity.Specialties);
            cmd.Parameters.AddWithValue("@is_actived", entity.IsActived);
            cmd.Parameters.AddWithValue("@commision_fee_by_product", entity.CommissionFeeByProduct);
            cmd.Parameters.AddWithValue("@commision_fee_by_service", entity.CommissionFeeByService);


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

    public async Task UpdateAsync(StaffEntity entity)
    {
        try
        {
            using var conn = GetConnection();
            await conn.OpenAsync();
             
            var sql = @"UPDATE clients SET id=@id, name=@name, phone=@phone, specialties=@specialties, is_actived=@is_actived, commision_fee_by_product=@commision_fee_by_product, commision_fee_by_service=@commision_fee_by_service WHERE id = @id ";

            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", entity.Id);
            cmd.Parameters.AddWithValue("@name", entity.Name);
            cmd.Parameters.AddWithValue("@phone", entity.Phone);
            cmd.Parameters.AddWithValue("@specialties", entity.Specialties);
            cmd.Parameters.AddWithValue("@is_actived", entity.IsActived);
            cmd.Parameters.AddWithValue("@commision_fee_by_product", entity.CommissionFeeByProduct);
            cmd.Parameters.AddWithValue("@commision_fee_by_service", entity.CommissionFeeByService);


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
