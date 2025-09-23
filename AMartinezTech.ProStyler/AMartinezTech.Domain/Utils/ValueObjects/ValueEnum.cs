using AMartinezTech.Domain.Utils.Exceptions;
using System.ComponentModel.DataAnnotations;

namespace AMartinezTech.Domain.Utils.ValueObjects;

public class ValueEnum<T> where T : struct, Enum
{
    public T Type { get; init; }

    private ValueEnum(T type)
    {
        Type = type;
    }

    public static ValueEnum<T> Create(string type)
    {
        var enumType = typeof(T);

        if (!Enum.TryParse(enumType, type, true, out object? parsedValue) || parsedValue == null || !Enum.IsDefined(enumType, parsedValue))
            throw new ValidationException(ErrorMessages.Get(ErrorType.InvalidType) + " - " + enumType.Name);

        return new ValueEnum<T>((T)parsedValue);
    }

    public override string ToString()
    {
        return Type.ToString();
    }
}
