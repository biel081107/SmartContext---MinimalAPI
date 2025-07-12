using SMARTSUPLEMENTOS.Models;
using SMARTSUPLEMENTOS.DTO;
using SMARTSUPLEMENTOS.Repositories;


namespace SMARTSUPLEMENTOS.Services;

public class ProdutoService : IProdutoService
{
    private readonly IProdutoRepository produtoRepository;

    public ProdutoService(IProdutoRepository _produtoRepository)
    {
        produtoRepository = _produtoRepository;
    }

    public async Task<IResult> RegisterProductAsync(ProdutoDTO newProduct)
    {
        if (newProduct == null)
            return Results.BadRequest("Não é possivel cadastrar um produto nulo!");

        if (string.IsNullOrEmpty(newProduct.Name))
            return Results.BadRequest("Nome do produto não pode ser nulo ou vazio");

        if (string.IsNullOrEmpty(newProduct.Description))
            return Results.BadRequest("Descrição do produto não pode ser nulo ou vazio");

        if (newProduct.Price < 0)
            return Results.BadRequest("Preço do produto não pode ser menor que 0");

        if (newProduct.Stock < 0)
            return Results.BadRequest("Estoque do produto não pode ser menor que 0");

        try
        {
            await produtoRepository.RegisterProductAsync(newProduct);

            return Results.Ok(newProduct);
        }
        catch (ArgumentException ex)
        {
            return Results.BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    public async Task<IResult> GetAllProductsAsync()
    {
        var allProducts = await produtoRepository.GetAllProductsAsync();

        if (allProducts == null)
            return Results.BadRequest("Não existe nenhum produto cadastrado no momento!");

        return Results.Ok(allProducts);
    }
    public async Task<IResult> UpdateProductAsync(ProdutoDTO newProduct)
    {
        if (newProduct == null)
            return Results.BadRequest("Não é possivel atualizar um produto nulo!");

        if (string.IsNullOrEmpty(newProduct.Name))
            return Results.BadRequest("Nome do produto não pode ser nulo ou vazio");

        if (string.IsNullOrEmpty(newProduct.Description))
            return Results.BadRequest("Descrição do produto não pode ser nulo ou vazio");

        if (newProduct.Price < 0)
            return Results.BadRequest("Preço do produto não pode ser menor que 0");

        if (newProduct.Stock < 0)
            return Results.BadRequest("Estoque do produto não pode ser menor que 0");

        try
        {
            await produtoRepository.UpdateProductAsync(newProduct);

            return Results.Ok("Produto Atualizado com Sucesso!");
        }
        catch (ArgumentException ex)
        {
            return Results.BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    public async Task<IResult> RemoveProduct(int IdProduct)
    {
        if (IdProduct <= 0)
            return Results.BadRequest("Id do produto não pode ser menor ou igual a 0");

        try
        {
            await produtoRepository.RemoveProduct(IdProduct);

            return Results.NoContent();
        }
        catch (ArgumentException ex)
        {
            return Results.BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
}