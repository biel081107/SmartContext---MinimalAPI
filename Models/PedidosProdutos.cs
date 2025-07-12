namespace SMARTSUPLEMENTOS.Models;

public class PedidoProduto
{
    public int PedidoId { get; set; }
    public Pedidos Pedido { get; set; } = null!; // Not null because it should always be associated with a Pedido

    public int ProdutoId { get; set; }
    public Produtos Produto { get; set; }  = null!;

    public int Quantidade { get; set; }

    public decimal PrecoUnitario { get; set; } // Preço no momento do pedido
}
