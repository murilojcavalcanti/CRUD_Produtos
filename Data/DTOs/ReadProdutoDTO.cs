using System.ComponentModel.DataAnnotations;

namespace Desafio_IBID.Data.DTOs;

public class ReadProdutoDTO
{
    public string Nome { get; set; }
    public string descrição { get; set; }
    public decimal Preco { get; set; }
    public int Quantidade { get; set; }
}
