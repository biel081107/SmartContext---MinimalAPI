namespace SMARTSUPLEMENTOS.Models;

public class Pedidos
{
    public int IdPedido { get; set; }
    public DateTime DataPedido { get; set; }
    public decimal ValorTotal { get; set; }

    public List<Produtos>? Produtos { get; set; }

    public List<PedidoProduto> PedidosProdutos { get; set; } = null!;
}