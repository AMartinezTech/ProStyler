using AMartinezTech.Application.Module.Administration.Interfaces;

namespace AMartinezTech.Application.Module.Administration.UseCases.Read;

public class UserFilter(IUserReadRepository repository)
{
    private readonly IUserReadRepository _repository = repository;

    public async Task<List<UserDto>> ExecuteAsync(string? filterStr, bool? isActived) 
    { 
        var result = await _repository.FilterAsync(filterStr, isActived);
        return UserMapper.ToDtoList(result);
    }
}
