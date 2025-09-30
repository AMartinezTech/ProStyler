using AMartinezTech.Application.Module.Administration.Settings.Interfaces;
using AMartinezTech.Domain.Module.Administration;
using AMartinezTech.Domain.Utils.Exceptions;
using AMartinezTech.Infrastucture.SqlServer.Utils.Exceptions;
using AMartinezTech.Infrastucture.SqlServer.Utils.Persistence;
using Microsoft.Data.SqlClient;

namespace AMartinezTech.Infrastucture.SqlServer.Module.Administration.Settings;

public class SettingWriteRepository(string connectionString) : AdoRepositoryBase(connectionString), ISettingWriteRepository
{
    public async Task CreateAsync(SettingEntity entity)
    { 
        try
        {
            using var conn = GetConnection();
            await conn.OpenAsync();


            var sql = @"INSERT INTO settings 
                        (id, 
                        company_name, 
                        line1, 
                        line2, 
                        line3, 
                        invoice_note, 
                        invoice_print_name, 
                        invoice_print_type)
                        VALUES(@id, 
                        @company_name, 
                        @line1, 
                        @line2, 
                        @line3, 
                        @invoice_note, 
                        @invoice_print_name, 
                        @invoice_print_type)";

            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", entity.Id);
            cmd.Parameters.AddWithValue("@company_name", entity.CompanyName);
            cmd.Parameters.AddWithValue("@line1", entity.Line1);
            cmd.Parameters.AddWithValue("@line2", entity.Line2);
            cmd.Parameters.AddWithValue("@line3", entity.Line3);
            cmd.Parameters.AddWithValue("@invoice_note", entity.InvoiceNote);
            cmd.Parameters.AddWithValue("@invoice_print_name", entity.InvoicePrintName);
            cmd.Parameters.AddWithValue("@invoice_print_type", entity.InvoicePrintType.ToString());


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

    public async Task UpdateAsync(SettingEntity entity)
    {
        try
        {
            using var conn = GetConnection();
            await conn.OpenAsync();


            var sql = @"UPDATE settings SET 
                        company_name=@company_name, 
                        line1=@line1, 
                        line2=@line2, 
                        line3=@line3, 
                        invoice_note=@invoice_note, 
                        invoice_print_name=@invoice_print_name, 
                        invoice_print_type=@invoice_print_type WHERE id=@id ";

            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", entity.Id);
            cmd.Parameters.AddWithValue("@company_name", entity.CompanyName);
            cmd.Parameters.AddWithValue("@line1", entity.Line1);
            cmd.Parameters.AddWithValue("@line2", entity.Line2);
            cmd.Parameters.AddWithValue("@line3", entity.Line3);
            cmd.Parameters.AddWithValue("@invoice_note", entity.InvoiceNote);
            cmd.Parameters.AddWithValue("@invoice_print_name", entity.InvoicePrintName);
            cmd.Parameters.AddWithValue("@invoice_print_type", entity.InvoicePrintType.ToString());


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
