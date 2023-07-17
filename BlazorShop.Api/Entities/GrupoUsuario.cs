using System.ComponentModel.DataAnnotations;

namespace BlazorShop.Api.Entities
{
    public class GrupoUsuario
    {
        [Key]
        public int IdGrupoUsuario { get; set; }
        
        [StringLength(20, ErrorMessage = "Numeros de Caracteres Exedido", ErrorMessageResourceName = "Error", MinimumLength = 3)]
        public string NomeGrupoUsuario { get; set; }
    }
}
