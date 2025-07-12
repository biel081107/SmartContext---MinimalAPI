using SMARTSUPLEMENTOS.Models;
using SMARTSUPLEMENTOS.DTO;
using SMARTSUPLEMENTOS.Data;
using SMARTSUPLEMENTOS.Repositories;
using Microsoft.EntityFrameworkCore;

namespace SMARTSUPLEMENTOS.Repositories;

public class PedidosRepository : IPedidosRepository
{
    private readonly SmartContext smartContext;
    private readonly IProdutoRepository produtoRepository;


    public PedidosRepository(SmartContext _smartContext, IProdutoRepository _produtoRepository)
    {
        smartContext = _smartContext;
        produtoRepository = _produtoRepository;
    }

    public async Task CreatePedidoAsync(Pedidos pedido)
    {
        if (pedido == null)
            throw new ArgumentNullException("Não foi possível criar o pedido, pois ele é nulo.");

        var produtos = await produtoRepository.GetAllProductsAsync();

        await smartContext.Pedidos.AddAsync(pedido);
        await smartContext.SaveChangesAsync();
    }

    public async Task<List<Pedidos>> GetAllPedidosAsync()
    {
        var pedidos = await smartContext.Pedidos
            .Include(p => p.PedidosProdutos)
                .ThenInclude(pp => pp.Produto)
            .ToListAsync();

        if (pedidos == null || !pedidos.Any())
            throw new InvalidOperationException("Não existem pedidos cadastrados.");

        return pedidos;
    }
};
