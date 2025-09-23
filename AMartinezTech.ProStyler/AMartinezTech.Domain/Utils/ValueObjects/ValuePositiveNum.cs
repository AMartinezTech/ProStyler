using AMartinezTech.Domain.Utils.Exceptions;
using System.ComponentModel.DataAnnotations;

namespace AMartinezTech.Domain.Utils.ValueObjects;

public class ValuePositiveNum
{
    public decimal Value { get; init; }
    private ValuePositiveNum(decimal value, string nameOfFeld)
    {
        if (value <= 0)
        {
            throw new ValidationException($" {ErrorMessages.Get(ErrorType.NoNegativeNum)}  - {nameOfFeld}! ");
        }
        Value = value;
    }

    public static ValuePositiveNum Create(decimal value, string nameOfFeld)
    {
        return new ValuePositiveNum(value, nameOfFeld);
    }
}
