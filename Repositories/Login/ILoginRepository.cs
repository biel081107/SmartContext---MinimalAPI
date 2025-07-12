using SMARTSUPLEMENTOS.Models;
using SMARTSUPLEMENTOS.DTO;

namespace SMARTSUPLEMENTOS.Repositories;

public interface IloginRepository
{
    public Task<IResult> LoginAsync(UsuarioDTO newUser);
    public Task RegisterAsync(Usuarios newUser);
}