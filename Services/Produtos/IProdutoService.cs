using SMARTSUPLEMENTOS.Models;
using SMARTSUPLEMENTOS.DTO;

namespace SMARTSUPLEMENTOS.Services;

public interface IProdutoService
{
    public Task<IResult> RegisterProductAsync(ProdutoDTO newProduct);
    public Task<IResult> GetAllProductsAsync();
    public Task<IResult> UpdateProductAsync(ProdutoDTO newProduct);
    public Task<IResult> RemoveProduct(int IdProduct);
}
