using AMartinezTech.Application.Module.Administration.Users.Interfaces;
using AMartinezTech.Application.Utils;
using AMartinezTech.Domain.Module.Administration;

namespace AMartinezTech.Application.Module.Administration.Users.UseCases.Write;

public class UserPersistence(IUserWriteRepository repository)
{
    private readonly IUserWriteRepository _repository = repository;

    public async Task<Guid> ExecuteAsync(UserDto dto)
    {
        Guid _id = GeneratesId.Make(dto.Id);
       var password = ValuePassword.Create(dto.PasswordHash, dto.ConfirmPasswordHash);
        var entity = UserEntity.Create(_id, dto.Name, dto.UserName, password, dto.Rol, dto.IsActived);

        if (dto.Id == Guid.Empty) { await _repository.CreateAsync(entity); } else { await _repository.UpdateAsync(entity); }

        return _id;
    }
}
