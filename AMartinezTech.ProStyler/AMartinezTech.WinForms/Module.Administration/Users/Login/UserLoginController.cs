using AMartinezTech.Application.Module.Administration.Users.UseCases.Read;

namespace AMartinezTech.WinForms.Module.Administration.Users.Login;

public class UserLoginController(UserLogin login)
{
    private readonly UserLogin _login = login;  

    public async Task<UserViewModel> LoginAsync(string username, string password)
    {
        var result = await _login.ExecuteAsync(username, password);
        return UserViewModel.ToModel(result);
    }
}
