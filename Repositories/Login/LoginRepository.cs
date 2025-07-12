using Microsoft.EntityFrameworkCore;
using BCrypt;
using SMARTSUPLEMENTOS.Data;
using SMARTSUPLEMENTOS.DTO;
using SMARTSUPLEMENTOS.Models;
using SMARTSUPLEMENTOS.Services;
using SMARTSUPLEMENTOS.Settings;

namespace SMARTSUPLEMENTOS.Repositories;

public class LoginRepository : IloginRepository
{
    private readonly SmartContext smartContext;
    private readonly JwtService jwtService;
    public LoginRepository(SmartContext _smartContext, JwtService _jwtService)
    {
        smartContext = _smartContext;
        jwtService = _jwtService;
    }

    public async Task<IResult> LoginAsync(UsuarioDTO newUser)
    {
        if (!smartContext.Usuarios.Any(c => newUser.Username == c.Username))
            return Results.NotFound();

        var user = await smartContext.Usuarios.FirstOrDefaultAsync(c => newUser.Username == c.Username);
        if (user == null)
            return Results.NotFound();

        var checkPassword = BCrypt.Net.BCrypt.Verify(newUser.Password, user.Password);

        if (!checkPassword)
            return Results.BadRequest("Senha Invalida!");

        var token = jwtService.GerarToken(user.Username, user.Role);

        return Results.Ok(new
        {
            message = "Token Abaixo: ",
            token = token   
        });
    }
    public async Task RegisterAsync(Usuarios newUser)
    {
        if (smartContext.Usuarios.Any(c => newUser.Username == c.Username))
            throw new ArgumentException("Erro! Não foi possivel registrar esse usuario! Já existe um com o mesmo email em nosso sistema");
        

        await smartContext.Usuarios.AddAsync(newUser);
        await smartContext.SaveChangesAsync();
        
        //The virifications will be on the service
    }
}