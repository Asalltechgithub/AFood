using BlazorShop.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorShop.Api.Context;

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
    public DbSet<GrupoUsuario> GrupoUsuario { get; set; }
    public DbSet<Pedido> Pedidos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        //Produtos
        //Beleza Category
       
      

        //Add users
        modelBuilder.Entity<Usuario>().HasData(new Usuario
        {
            Id = 1,
            NomeUsuario = "ADM", Password = "AdmSenha",
            Email="ADM@ASFood.com".ToUpper(),
            GrupoUsuarioId=1, 
            

        });
        modelBuilder.Entity<GrupoUsuario>().HasData(new GrupoUsuario
        {
           
             IdGrupoUsuario = 1,
              NomeGrupoUsuario="Administrador"
        });
        modelBuilder.Entity<GrupoUsuario>().HasData(new GrupoUsuario
        {

            IdGrupoUsuario = 2,
            NomeGrupoUsuario = "Gerente"
        });

        modelBuilder.Entity<GrupoUsuario>().HasData(new GrupoUsuario
        {

            IdGrupoUsuario = 3,
            NomeGrupoUsuario = "Cliente"
        });
        //Create Shopping Carrinho for Users
        modelBuilder.Entity<Carrinho>().HasData(new Carrinho
        {
            Id = 1,
            UsuarioId = "1"
            ,
            StatusCarrinho = "Fechado"

        });
        modelBuilder.Entity<Carrinho>().HasData(new Carrinho
        {
            Id = 2,
            UsuarioId = "2", StatusCarrinho="Fechado"

        });
        //Add Produto Categories
        modelBuilder.Entity<Categoria>().HasData(new Categoria
        {
            Id = 1,
            Nome = "Sanduiches",
            IconCSS = "fas fa-spa"
        });
        modelBuilder.Entity<Categoria>().HasData(new Categoria
        {
            Id = 2,
            Nome = "Açai",
            IconCSS = "fas fa-couch"
        });
        modelBuilder.Entity<Categoria>().HasData(new Categoria
        {
            Id = 3,
            Nome = "Porções",
            IconCSS = "fas fa-headphones"
        });
        modelBuilder.Entity<Categoria>().HasData(new Categoria
        {
            Id = 4,
            Nome = "Bebidas",
            IconCSS = "fas fa-shoe-prints"
        });
        modelBuilder.Entity<Categoria>().HasData(new Categoria
        {
            Id = 5,
            Nome = "Combos",
            IconCSS = "fas fa-shoe-prints"
        });
        modelBuilder.Entity<Categoria>().HasData(new Categoria
        {
            Id = 6,
            Nome = "Pizzas",
            IconCSS = "fas fa-shoe-prints"
        });
        modelBuilder.Entity<Categoria>().HasData(new Categoria
        {
            Id = 7,
            Nome = "Sorvete",
            IconCSS = "fas fa-shoe-prints"
        });
    }
}