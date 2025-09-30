using AMartinezTech.Application.Module.Administration.Users;
using AMartinezTech.Application.Module.Administration.Users.UseCases.Read;
using AMartinezTech.Application.Module.Administration.Users.UseCases.Write;
using System.ComponentModel;

namespace AMartinezTech.WinForms.Module.Administration.Users;

public class UserController(UserPersistence persistence, UserGetById getById, UserFilter filter)
{
    private readonly UserPersistence _persistence = persistence;
    private readonly UserGetById _getById = getById;
    private readonly UserFilter _filter = filter;

    public async Task<Guid> PersistenceAsync(UserDto dto)
    {
        return await _persistence.ExecuteAsync(dto);
    }
    public async Task<UserDto> GetByIdAsync(Guid id)
    {
        return await _getById.ExecuteAsync(id);
    }
    public async Task<BindingList<UserViewModel>> FilterAsync(string? filterStr, bool? isActived)
    {
        var result = await _filter.ExecuteAsync(filterStr, isActived);
        return new BindingList<UserViewModel>(UserViewModel.ToModelList(result));
    }
}
