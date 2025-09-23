using AMartinezTech.Domain.Utils.Exceptions; 

namespace AMartinezTech.Domain.Module.Products;

public class ValueProductCategoryName
{
    public string Value { get; init; }

    private ValueProductCategoryName(string value)
    {
        Value = value;
    }

    public static ValueProductCategoryName Create(string value)
    {
        if (string.IsNullOrEmpty(value))
            throw new Exception($"{ErrorMessages.Get(ErrorType.RequiredField)} - name");

        if (value.Length < 4)
            throw new Exception($"{ErrorMessages.Get(ErrorType.MinLength)} 4 - name");

        return new ValueProductCategoryName(value);
    }
}
