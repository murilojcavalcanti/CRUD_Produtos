using System.ComponentModel.DataAnnotations;

namespace Desafio_IBID.Models
{
    public class Produto
    {

        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string descrição { get; set; }

        [Required]
        public decimal Preco { get; set; }

        [Required]
        public int Quantidade { get; set; }
    }
}
