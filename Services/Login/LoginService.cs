using SMARTSUPLEMENTOS.Data;
using SMARTSUPLEMENTOS.Models;
using SMARTSUPLEMENTOS.DTO;
using SMARTSUPLEMENTOS.Repositories;


namespace SMARTSUPLEMENTOS.Services;

public class LoginService : ILoginService
{
    private readonly IloginRepository loginRepository;

    public LoginService(IloginRepository _loginRepository)
    {
        loginRepository = _loginRepository;
    }

    public async Task<IResult> LoginAsync(UsuarioDTO newUser)
    {
        if (newUser == null)
            return Results.BadRequest("Usuario invalido! Por favor verifique os campos e tente novamente!");

        if (newUser.Username == null)
            return Results.BadRequest("Nome de usuario não pode ser nulo, verfique os campos e tente novamente!");

        if (newUser.Password == null)
            return Results.BadRequest("Senha invalida! Por favor verfique os campos e tente novamente!");

        return await loginRepository.LoginAsync(newUser);
    }
    public async Task<IResult> RegisterAsync(UsuarioDTO newUser)
    {
        if (newUser == null)
            return Results.BadRequest("Usuario invalido! Por favor verifique os campos e tente novamente!");

        if (newUser.Username == null)
            return Results.BadRequest("Nome de usuario não pode ser nulo, verfique os campos e tente novamente!");

        var usuarioX = new Usuarios
        {
            Username = newUser.Username,
            Password = BCrypt.Net.BCrypt.HashPassword(newUser.Password),
            Role = "User"
        };

        try
        {
            await loginRepository.RegisterAsync(usuarioX);
            return Results.Ok("Usuario cadastrado com sucesso!");
        }
        catch (ArgumentException ex)
        {
            return Results.BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
}