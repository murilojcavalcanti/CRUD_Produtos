using System.ComponentModel.DataAnnotations;

namespace Desafio_IBID.Data.DTOs;

public class CreateProdutoDTO
{
    [Required]
    public string Nome { get; set; }

    [Required]
    [DataType(DataType.Text)]
    public string descrição { get; set; }

    [Required]
    public decimal Preco { get; set; }

}
