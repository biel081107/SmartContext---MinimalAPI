using SMARTSUPLEMENTOS.DTO;
using SMARTSUPLEMENTOS.Models;
using SMARTSUPLEMENTOS.Repositories;

namespace SMARTSUPLEMENTOS.Services;

public interface IPedidosService
{
    public Task<IResult> CreatePedidoAsync(AddPedidoDTO pedidoDto);
    public Task<IResult> GetAllPedidosAsync();
}