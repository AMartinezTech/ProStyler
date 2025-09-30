using AMartinezTech.Domain.Utils.Exceptions;

namespace AMartinezTech.Domain.Module.Administration;


public class ValueUserName
{
    public string Value { get; init; }

    private ValueUserName(string value)
    {
        Value = value;
    }

    public static ValueUserName Create(string value)
    {
        if (string.IsNullOrEmpty(value))
            throw new Exception($"{ErrorMessages.Get(ErrorType.RequiredField)} - user name");

        if (value.Length < 4)
            throw new Exception($"{ErrorMessages.Get(ErrorType.MinLength)} 4 - user name");

        if (value.Length > 50)
            throw new Exception($"{ErrorMessages.Get(ErrorType.MinLength)} 50 - user name");

        return new ValueUserName(value);
    }
}
