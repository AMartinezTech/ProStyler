namespace AMartinezTech.Domain.Utils.Exceptions;

public enum ErrorType
{
    RequiredField,
    InvalidFormat,
    InvalidType,
    MaxLength,
    MinLength,
    NoNegativeNum,
    PostiveNum,
    RangeValid,
    NullDetails,
    RecordDoesDotExist,
    RecordCreateError,
    RecordUpdateError,
    RecordDeleteError,
    DataBaseUnknownError,
    PasswordNotMatch,
    InvalidCredentials
}
