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
            throw new Exception($"{ErrorMessages.Get(ErrorType.RequiredField)} - name");

        if (value.Length < 8)
            throw new Exception($"{ErrorMessages.Get(ErrorType.MinLength)} 8 - name");

        return new ValueName(value);
    }
}
