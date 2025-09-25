using Microsoft.Data.SqlClient;

namespace AMartinezTech.Infrastucture.Utils.SqlServer.Exceptions;

public static class SqlErrorMapper
{
    /// <summary>
    /// Mapea un SqlException a un mensaje amigable
    /// </summary>
    public static string Map(SqlException ex)
    {
        return ex.Number switch
        {
            2627 => "Registro duplicado: ya existe un elemento con el mismo valor.",
            2601 => "Registro duplicado: restricción de índice único violada.",
            547 => "Violación de restricción: no se puede realizar la operación debido a relación con otra tabla.",
            208 => "Tabla no encontrada en la base de datos.",
            53 => "No se puede conectar al servidor de base de datos.",
            _ => "Ocurrió un error en la base de datos."
        };
    }
}
