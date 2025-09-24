using AMartinezTech.Domain.Utils.Exceptions; 

namespace AMartinezTech.Domain.Module.Items;

public class ValueItemCategoryName
{
    public string Value { get; init; }

    private ValueItemCategoryName(string value)
    {
        Value = value;
    }

    public static ValueItemCategoryName Create(string value)
    {
        if (string.IsNullOrEmpty(value))
            throw new Exception($"{ErrorMessages.Get(ErrorType.RequiredField)} - name");

        if (value.Length < 4)
            throw new Exception($"{ErrorMessages.Get(ErrorType.MinLength)} 4 - name");

        return new ValueItemCategoryName(value);
    }
}
