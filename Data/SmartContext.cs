using Microsoft.EntityFrameworkCore;
using SMARTSUPLEMENTOS.Models;

namespace SMARTSUPLEMENTOS.Data;

public class SmartContext : DbContext
{
    public SmartContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Usuarios> Usuarios { get; set; }
    public DbSet<Produtos> Produtos { get; set; }
    public DbSet<Pedidos> Pedidos { get; set; }
    public DbSet<PedidoProduto> PedidosProdutos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Usuarios>(e =>
        {
            e.HasKey(c => c.Id);
            e.Property(c => c.Username).IsRequired().HasMaxLength(100);
            e.Property(c => c.Role).IsRequired();
            e.Property(c => c.Password).IsRequired().HasMaxLength(256);
        });

        modelBuilder.Entity<Produtos>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.ProdutoName).IsRequired().HasMaxLength(200);
            entity.Property(e => e.Description).IsRequired().HasMaxLength(500);
            entity.Property(e => e.Price).HasColumnType("decimal(10,2)").IsRequired();
            entity.Property(e => e.Stock).IsRequired().HasDefaultValue(0);
        });

        modelBuilder.Entity<Pedidos>(entity =>
        {
            entity.HasKey(e => e.IdPedido);
            entity.Property(e => e.DataPedido).IsRequired();
            entity.Property(e => e.ValorTotal).HasColumnType("decimal(10,2)").IsRequired();
        });

        // Aqui a gente configura a TABELA INTERMEDIÁRIA corretamente:

        modelBuilder.Entity<PedidoProduto>(entity =>
        {
            entity.HasKey(pp => new { pp.PedidoId, pp.ProdutoId }); // Chave composta

            entity.HasOne(pp => pp.Pedido)
                .WithMany(p => p.PedidosProdutos)
                .HasForeignKey(pp => pp.PedidoId);

            entity.HasOne(pp => pp.Produto)
                .WithMany(p => p.PedidosProdutos)
                .HasForeignKey(pp => pp.ProdutoId);

            entity.Property(pp => pp.Quantidade).IsRequired();

            entity.Property(pp => pp.PrecoUnitario)
                .HasColumnType("decimal(10,2)")
                .IsRequired();
        });
    }
}
