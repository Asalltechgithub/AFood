

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebShop.Backoffice.Entities;

namespace WebShop.Backoffice.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { }
    public DbSet<Carrinho>? Carrinhos { get; set; }
    public DbSet<CarrinhoItem>? CarrinhoItens { get; set; }
    public DbSet<Produto>? Produtos { get; set; }
    public DbSet<Categoria>? Categorias { get; set; }
    public DbSet<Usuario>? Usuarios { get; set; }
    public DbSet<Endereco>? Endereco { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        
    }
}