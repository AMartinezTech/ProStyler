using AMartinezTech.Application.Module.Administration.Users;

namespace AMartinezTech.WinForms.Module.Administration.Users;

public class UserViewModel
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool IsActived { get; set; }
    public string IsActiveName => IsActived ? "Activo" : "Inactivo";

    public static UserViewModel ToModel(UserDto dto)
    {
        return new UserViewModel { Id = dto.Id, Name = dto.Name, IsActived = dto.IsActived };
    }

    public static List<UserViewModel> ToModelList(List<UserDto> list) 
    {
        return [.. list.Select(ToModel).ToList()];
    }
}
