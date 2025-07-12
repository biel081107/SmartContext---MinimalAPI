using SMARTSUPLEMENTOS.Models;
using SMARTSUPLEMENTOS.DTO;
using Microsoft.Identity.Client;

namespace SMARTSUPLEMENTOS.Repositories;

public interface IProdutoRepository
{
    public Task RegisterProductAsync(ProdutoDTO newProduct);
    public Task<List<Produtos>> GetAllProductsAsync();
    public Task UpdateProductAsync(ProdutoDTO newProduct);
    public Task RemoveProduct(int IdProduct);
}