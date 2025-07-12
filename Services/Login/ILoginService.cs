using SMARTSUPLEMENTOS.Data;
using SMARTSUPLEMENTOS.Models;
using SMARTSUPLEMENTOS.DTO;


namespace SMARTSUPLEMENTOS.Services;


public interface ILoginService
{
    public Task<IResult> LoginAsync(UsuarioDTO newUser);
    public Task<IResult> RegisterAsync(UsuarioDTO newUser);
}