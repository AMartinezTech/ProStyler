using AMartinezTech.Domain.Module.Appointments;
using Microsoft.Data.SqlClient;

namespace AMartinezTech.Infrastucture.Module.Appointments;

internal class MapToAppointment
{
    internal static AppointmentEntity ToEntity(SqlDataReader reader)
    {
        var id = reader.GetGuid(reader.GetOrdinal("id"));
        var staffId = reader.GetGuid(reader.GetOrdinal("staff_id"));
        var staffName = reader.GetString(reader.GetOrdinal("staff_name"));
        var clientId = reader.GetGuid(reader.GetOrdinal("client_id"));
        var clientName = reader.GetString(reader.GetOrdinal("client_name"));

        // Convertir de DateTime (SQL) a TimeOnly (.NET)
        var assignedTime = TimeOnly.FromDateTime(reader.GetDateTime(reader.GetOrdinal("asigned_time")));
        var limitTime = TimeOnly.FromDateTime(reader.GetDateTime(reader.GetOrdinal("limit_time")));

        var createdAt = reader.GetDateTime(reader.GetOrdinal("created_at"));
        var status = reader.GetString(reader.GetOrdinal("status"));

       
        return AppointmentEntity.Create(id, staffId, staffName, clientId, clientName, assignedTime, limitTime, createdAt, status);
         
    }

    internal static AppointmentServiceEntity ToEntityService(SqlDataReader reader)
    {
        var appointmentId = reader.GetGuid(reader.GetOrdinal("appointment_id"));
        var serviceId = reader.GetGuid(reader.GetOrdinal("service_id"));
        var serviceName = reader.GetString(reader.GetOrdinal("service_name"));
        var quantity = reader.GetInt32(reader.GetOrdinal("quantity"));
        var price = reader.GetDecimal(reader.GetOrdinal("price"));

        return AppointmentServiceEntity.Create(appointmentId, serviceId, serviceName, quantity, price);
    }
}

