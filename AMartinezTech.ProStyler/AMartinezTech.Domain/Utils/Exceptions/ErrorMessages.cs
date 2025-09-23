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
            ErrorType.PostiveNum => "El valor númerico debe ser mayor a 0.00.",
            ErrorType.RangeValid => "El rango permitdo es",
            ErrorType.NullDetails => "El detalle es obligatorio",
            _ => "Error no definido",
        };
    }
}

