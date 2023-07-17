using System.ComponentModel.DataAnnotations;

namespace WebShop.Backoffice.Entities
{
    public class Endereco
    {
        [Key]
        public int EnderecoId { get; set; }
        public int UsuarioId { get; set; }
        [MaxLength(100)]
        public string NomeRua { get; set; }
        [MaxLength(100)]
        public string Complemento { get; set; }
        [MaxLength(20)]
        public string CEP { get; set; }
        [MaxLength(30)]
        public string Cidade { get; set; }
        [MaxLength(30)]
        public string Estado { get; set; }
    }
}
