using System.ComponentModel.DataAnnotations;

namespace WebShop.Backoffice.Entities;

public class Usuario
{
    public int Id { get; set; }
    [MaxLength(100)]
    public string NomeUsuario { get; set; } = string.Empty;
    [MaxLength(100)]
    public string Email { get; set; }
    [MaxLength(100)]
    public List<Endereco>? Endereco { get; set; }
    [MaxLength(30)]
    public string? Contato { get; set; }
    [MaxLength(100)]
    public string? Password { get; set; }
    public int GrupoUsuarioId { get; set; }

    public GrupoUsuario? Grupo { get; set; }

    public Carrinho? Carrinho { get; set; }
}

public class GrupoUsuario
{
    [Key]
    public int IdGrupoUsuario { get; set; }

    [StringLength(20, ErrorMessage = "Numeros de Caracteres Exedido", ErrorMessageResourceName = "Error", MinimumLength = 3)]
    public string NomeGrupoUsuario { get; set; }
}