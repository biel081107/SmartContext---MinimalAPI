using SMARTSUPLEMENTOS.DTO;
using SMARTSUPLEMENTOS.Data;
using SMARTSUPLEMENTOS.Services;
using SMARTSUPLEMENTOS.Models;

public static class PedidoEndPoint
{
    public static void MapPedidoEndPoint(this WebApplication app)
    {
        app.MapGet("/pedidos", async (IPedidosService pedidosService) =>
        {
            return await pedidosService.GetAllPedidosAsync();
        }).WithTags("Pedidos").RequireAuthorization("Admin");
        app.MapPost("/pedidos", async (AddPedidoDTO pedidoDto, IPedidosService pedidosService) =>
        {
            return await pedidosService.CreatePedidoAsync(pedidoDto);
        }).WithTags("Pedidos").RequireAuthorization("Admin");
    }
}