using SMARTSUPLEMENTOS.Models;

namespace SMARTSUPLEMENTOS.DTO;

public class AddPedidoDTO
{
    public List<AddPedidoItemDTO> Produtos { get; set; } = null!;
}

public class AddPedidoItemDTO
{
    public int ProdutoId { get; set; }
    public int Quantidade { get; set; }
}
