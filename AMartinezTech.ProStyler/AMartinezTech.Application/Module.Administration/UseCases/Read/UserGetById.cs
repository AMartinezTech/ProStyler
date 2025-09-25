using AMartinezTech.Application.Module.Administration.Interfaces;

namespace AMartinezTech.Application.Module.Administration.UseCases.Read;

public class UserGetById(IUserReadRepository repository)
{
    private readonly IUserReadRepository _repository = repository;

    public async Task<UserDto> ExecuteAsync(Guid id)
    {
        var result = await _repository.GetByIdAsync(id);
        return UserMapper.ToDto(result);
    }
}
