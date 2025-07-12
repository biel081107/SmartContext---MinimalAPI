using SMARTSUPLEMENTOS.DTO;
using SMARTSUPLEMENTOS.Data;
using SMARTSUPLEMENTOS.Services;
using SMARTSUPLEMENTOS.Models;

public static class ProdutoEndPoint
{
    public static void MapProdutoEndPoint(this WebApplication app)
    {
        app.MapGet("/produtos", async (IProdutoService db) =>
        {
            return await db.GetAllProductsAsync();
        }).WithTags("Produtos");

        app.MapPost("/produtos", async (ProdutoDTO newProduct, IProdutoService db) =>
        {
            return await db.RegisterProductAsync(newProduct);
        }).WithTags("Produtos").RequireAuthorization("Admin");

        app.MapPut("/produtos", async (ProdutoDTO newProduct, IProdutoService db) =>
        {
            return await db.UpdateProductAsync(newProduct);
        }).WithTags("Produtos").RequireAuthorization("Admin");

        app.MapDelete("/produtos/{id}", async (int id, IProdutoService db) =>
        {
            return await db.RemoveProduct(id);
        }).WithTags("Produtos").RequireAuthorization("Admin");
    }
}