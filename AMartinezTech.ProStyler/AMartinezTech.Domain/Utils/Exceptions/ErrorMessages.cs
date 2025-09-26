namespace AMartinezTech.Domain.Utils.Exceptions;

public class ErrorMessages
{
    public static string Get(ErrorType errorType)
    {
        return errorType switch
        {
            ErrorType.RequiredField => "Éste campo es requerido.",
            ErrorType.InvalidFormat => "Formato invalido.",
            ErrorType.InvalidType => "Tipo de datos invalido.",
            ErrorType.MaxLength => "Longitud máxima de caractéres.",
            ErrorType.MinLength => "Longitud mínima de caractéres.",
            ErrorType.NoNegativeNum => "El valor númerico no puede cero o ser negativo.",
            ErrorType.PostiveNum => "El valor númerico debe ser mayor a cero.",
            ErrorType.RangeValid => "El rango permitdo es",
            ErrorType.NullDetails => "El detalle es obligatorio",
            ErrorType.RecordDoesDotExist => "El registro no existe.!",
            ErrorType.RecordCreateError => "Error creando el registro.!",
            ErrorType.RecordUpdateError => "Error actualizando el registro.!",
            ErrorType.RecordDeleteError => "Error borrando el registro.!",
            ErrorType.DataBaseUnknownError => "Error desconocido de base de datos.!",
            _ => "Error no definido",
        };
    }  
}

