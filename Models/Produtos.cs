namespace SMARTSUPLEMENTOS.Models;

public class Produtos
{
    public int Id { get; set; }
    public string ProdutoName { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Description { get; set; } = string.Empty;
    public int Stock { get; set; }

    public List<PedidoProduto> PedidosProdutos { get; set; } = null!; // Navegação reversa
}