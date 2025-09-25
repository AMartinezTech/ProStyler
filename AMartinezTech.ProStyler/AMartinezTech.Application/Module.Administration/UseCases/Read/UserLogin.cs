using AMartinezTech.Application.Module.Administration.Interfaces;

namespace AMartinezTech.Application.Module.Administration.UseCases.Read;

public class UserLogin(IUserReadRepository repository)
{
    private readonly IUserReadRepository _repository = repository;

    public async Task<UserDto> ExecuteAsync(string username, string password)
    {
        var result = await _repository.LoginAsync(username, password);
        return UserMapper.ToDto(result);
    }
}
