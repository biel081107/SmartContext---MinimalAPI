using SMARTSUPLEMENTOS.DTO;
using SMARTSUPLEMENTOS.Models;
using SMARTSUPLEMENTOS.Repositories;

namespace SMARTSUPLEMENTOS.Services;

public class PedidosService : IPedidosService
{
    private readonly IPedidosRepository _pedidosRepository;
    private readonly IProdutoRepository _produtoRepository;

    public PedidosService(IPedidosRepository pedidosRepository, IProdutoRepository produtoRepository)
    {
        _pedidosRepository = pedidosRepository;
        _produtoRepository = produtoRepository;
    }

    public async Task<IResult> CreatePedidoAsync(AddPedidoDTO pedidoDto)
    {
        if (pedidoDto == null || pedidoDto.Produtos == null || !pedidoDto.Produtos.Any())
        {
            return Results.BadRequest("Pedido inválido. Verifique os dados enviados e tente novamente.");
        }
        if (pedidoDto.Produtos.Any(p => p.ProdutoId <= 0 || p.Quantidade <= 0))
        {
            return Results.BadRequest("Todos os produtos devem ter um ID válido e uma quantidade maior que zero.");
        }

        var produtos = await _produtoRepository.GetAllProductsAsync();

        if (produtos == null || !produtos.Any())
        {
            return Results.BadRequest("Não foi possível criar o pedido, pois não existem produtos cadastrados.");
        }
        if (!pedidoDto.Produtos.All(produtoPedido => produtos.Any(p => p.Id == produtoPedido.ProdutoId)))
        {
            return Results.BadRequest("Não foi possível criar o pedido, pois algum produto adicioando não existe no banco de dados.");
        }

        var produtosIdsDoPedido = pedidoDto.Produtos.Select(p => p.ProdutoId).ToList();
        var produtosOnPedido = produtos.Where(p => produtosIdsDoPedido.Contains(p.Id)).ToList();

        var valorTotal = produtosOnPedido.Sum(p => p.Price * pedidoDto.Produtos.FirstOrDefault(produto => produto.ProdutoId == p.Id)?.Quantidade ?? 0);

        if (valorTotal <= 0)
        {
            return Results.BadRequest("O valor total do pedido não pode ser zero ou negativo.");
        }

        // Cria os registros da tabela intermediária PedidoProduto
        var pedidosProdutos = pedidoDto.Produtos.Select(produtoDto => new PedidoProduto
        {
            ProdutoId = produtoDto.ProdutoId,
            Quantidade = produtoDto.Quantidade,
            PrecoUnitario = produtosOnPedido.First(p => p.Id == produtoDto.ProdutoId).Price
        }).ToList();

        var pedidoX = new Pedidos
        {
            DataPedido = DateTime.Now,
            ValorTotal = valorTotal,
            PedidosProdutos = pedidosProdutos
        };

        try
        {
            await _pedidosRepository.CreatePedidoAsync(pedidoX);
            return Results.Ok("Pedido criado com sucesso.");
        }
        catch (ArgumentNullException ex)
        {
            return Results.BadRequest($"Erro ao criar o pedido: {ex.Message}");
        }
        catch (Exception ex)
        {
            return Results.Problem($"Erro inesperado ao criar o pedido: {ex.Message}");
        }
    }
    public async Task<IResult> GetAllPedidosAsync()
    {
        try
        {
            var pedidos = await _pedidosRepository.GetAllPedidosAsync();
            if (pedidos == null || !pedidos.Any())
            {
                return Results.NotFound("Não existem pedidos cadastrados.");
            }

            var pedidosComProdutos = pedidos.Select(p => new
            {
                p.IdPedido,
                p.DataPedido,
                p.ValorTotal,
                Produtos = p.PedidosProdutos.Select(pp => new
                {
                    pp.ProdutoId,
                    pp.Quantidade,
                    pp.PrecoUnitario,
                    ProdutoNome = pp.Produto?.ProdutoName
                }).ToList()
            });

            return Results.Ok(pedidosComProdutos);
        }
        catch (InvalidOperationException ex)
        {
            return Results.NotFound($"Erro ao buscar pedidos: {ex.Message}");
        }
        catch (Exception ex)
        {
            return Results.Problem($"Erro inesperado ao buscar pedidos: {ex.Message}");
        }
    }


}