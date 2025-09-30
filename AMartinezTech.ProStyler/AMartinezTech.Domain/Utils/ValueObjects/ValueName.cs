using AMartinezTech.Domain.Utils.Exceptions;

namespace AMartinezTech.Domain.Utils.ValueObjects;

public class ValueName
{
    public string Value { get; init; }

    private ValueName(string value)
    {
        Value = value;
    }

    public static ValueName Create(string value)
    {
        if (string.IsNullOrEmpty(value))
            throw new Exception($"{ErrorMessages.Get(ErrorType.RequiredField)} - FullName");

        if (value.Length < 8)
            throw new Exception($"{ErrorMessages.Get(ErrorType.MinLength)} 8 - FullName");

        if (value.Length > 99)
            throw new Exception($"{ErrorMessages.Get(ErrorType.MaxLength)} 99 - FullName");

        return new ValueName(value);
    }
}
