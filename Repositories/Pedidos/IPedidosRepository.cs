using SMARTSUPLEMENTOS.Models;
using SMARTSUPLEMENTOS.DTO;

namespace SMARTSUPLEMENTOS.Repositories;

public interface IPedidosRepository
{
    //public Task<List<Pedidos>> GetAllPedidosAsync();
    public Task CreatePedidoAsync(Pedidos pedido);
    public Task<List<Pedidos>> GetAllPedidosAsync(); 
}