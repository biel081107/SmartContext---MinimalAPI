namespace SMARTSUPLEMENTOS.DTO;

public class ProdutoDTO
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Stock { get; set; }
    public decimal Price { get; set; }
}