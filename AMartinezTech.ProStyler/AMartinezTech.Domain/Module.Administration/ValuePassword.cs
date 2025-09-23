using AMartinezTech.Domain.Utils.Exceptions;
using System.Text.RegularExpressions;

namespace AMartinezTech.Domain.Module.Administration;

public class ValuePassword
{
    public string Value { get; }

    private ValuePassword(string value)
    {
        Value = value;
    }

    public static ValuePassword Create(string value, int minLength = 6, int maxLength = 12)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new Exception($"{ErrorMessages.Get(ErrorType.RequiredField)} - clave");

        if (value.Length < minLength || value.Length > maxLength)
            throw new Exception($"La clave debe tener entre {minLength} y {maxLength} caracteres.");

        // Validación: al menos una letra y un número
        var regex = new Regex(@"^(?=.*[A-Za-z])(?=.*\d).+$");
        if (!regex.IsMatch(value))
            throw new Exception("La clave debe contener al menos una letra y un número.");

        return new ValuePassword(value);
    }

    public override int GetHashCode() => Value.GetHashCode();

    public override string ToString() => Value;
}
