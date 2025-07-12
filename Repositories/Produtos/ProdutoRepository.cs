using SMARTSUPLEMENTOS.Models;
using SMARTSUPLEMENTOS.DTO;
using SMARTSUPLEMENTOS.Data;
using Microsoft.EntityFrameworkCore;


namespace SMARTSUPLEMENTOS.Repositories;

public class ProdutoRepository : IProdutoRepository
{
    private readonly SmartContext smartContext;

    public ProdutoRepository(SmartContext _smartContext)
    {
        smartContext = _smartContext;
    }

    public async Task RegisterProductAsync(ProdutoDTO newProduct)
    {
        if (newProduct == null)
            throw new ArgumentException("Não é Possivem adicionar um produto nulo");

        if (smartContext.Produtos.Any(c => c.ProdutoName == newProduct.Name))
            throw new ArgumentException("Já existe um produto com esse nome cadastrado!");

        var produtoNew = new Produtos
        {
            ProdutoName = newProduct.Name,
            Description = newProduct.Description,
            Price = newProduct.Price,
            Stock = newProduct.Stock
        };

        await smartContext.Produtos.AddAsync(produtoNew);
        await smartContext.SaveChangesAsync();
    }
    public async Task<List<Produtos>> GetAllProductsAsync()
    {
        var allProducts = await smartContext.Produtos.ToListAsync();

        return allProducts;
    }

    public async Task UpdateProductAsync(ProdutoDTO newProduct)
    {
        var productX = await smartContext.Produtos.FirstOrDefaultAsync(c => c.ProdutoName == newProduct.Name);

        if (productX == null)
            throw new ArgumentException("Erro ao tentar atualizar um produto que não existe!");

        productX.ProdutoName = newProduct.Name;
        productX.Description = newProduct.Description;
        productX.Price = newProduct.Price;
        productX.Stock = newProduct.Stock;

        await smartContext.SaveChangesAsync();
    }
    public async Task RemoveProduct(int IdProduct)
    {
        var productX = await smartContext.Produtos.FirstOrDefaultAsync(c => c.Id == IdProduct);

        if (productX == null)
            throw new ArgumentException("Erro! Não é possivel remover um produto que não existe!");

        smartContext.Remove(productX);

        await smartContext.SaveChangesAsync();
    }

}