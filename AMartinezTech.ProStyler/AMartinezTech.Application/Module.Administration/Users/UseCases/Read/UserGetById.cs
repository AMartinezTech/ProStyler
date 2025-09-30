using AMartinezTech.Application.Module.Administration.Users.Interfaces;

namespace AMartinezTech.Application.Module.Administration.Users.UseCases.Read;

public class UserGetById(IUserReadRepository repository)
{
    private readonly IUserReadRepository _repository = repository;

    public async Task<UserDto> ExecuteAsync(Guid id)
    {
        var result = await _repository.GetByIdAsync(id);
        return UserMapper.ToDto(result);
    }
}
