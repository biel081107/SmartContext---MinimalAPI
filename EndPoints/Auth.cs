using SMARTSUPLEMENTOS.DTO;
using SMARTSUPLEMENTOS.Data;
using SMARTSUPLEMENTOS.Services;
using SMARTSUPLEMENTOS.Models;

public static class Auth
{
    public static void MapAuthEndPoint(this WebApplication app)
    {
        app.MapPost("/auth/register", (UsuarioDTO dto, ILoginService loginService) =>
        {
            return loginService.RegisterAsync(dto);
        }).WithTags("Login");
        app.MapPost("/auth/login", (UsuarioDTO dto, ILoginService loginService) =>
        {
            return loginService.LoginAsync(dto);
        }).WithTags("Login");;
    }
}