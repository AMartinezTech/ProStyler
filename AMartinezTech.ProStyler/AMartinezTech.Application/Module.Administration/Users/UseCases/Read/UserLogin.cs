using AMartinezTech.Application.Module.Administration.Users.Interfaces;
using AMartinezTech.Domain.Utils.Exceptions;

namespace AMartinezTech.Application.Module.Administration.Users.UseCases.Read;

public class UserLogin(IUserReadRepository repository)
{
    private readonly IUserReadRepository _repository = repository;

    public async Task<UserDto> ExecuteAsync(string username, string password)
    {

        if (string.IsNullOrWhiteSpace(username)) throw new Exception($"{ErrorMessages.Get(ErrorType.RequiredField)} - UserName");
        if (string.IsNullOrWhiteSpace(password)) throw new Exception($"{ErrorMessages.Get(ErrorType.RequiredField)} - Password");
        var result = await _repository.LoginAsync(username, password);
        return UserMapper.ToDto(result);
    }
}
