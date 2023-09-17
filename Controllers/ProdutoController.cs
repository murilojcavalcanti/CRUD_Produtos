using AutoMapper;
using Desafio_IBID.Data;
using Desafio_IBID.Data.DTOs;
using Desafio_IBID.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Desafio_IBID.Controllers;

[ApiController]
[Route("[Controller]")]
public class ProdutoController:ControllerBase
{
    private ProdutoDbContext Context;
    private IMapper Mapper;

    public ProdutoController(IMapper mapper, ProdutoDbContext context)
    {
        Context = context;
        Mapper = mapper;
    }
    
    /// <summary>
    /// Adiciona um Produto ao banco de dados
    /// </summary>
    /// <param name="produtoDto"> Objeto com os campos necessários para criação de um produto</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult AdicionaProduto(CreateProdutoDTO produtoDTO)
    {
        var produto = Mapper.Map<Produto>(produtoDTO);
        Context.Produtos.Add(produto);
        Context.SaveChanges();
        return Ok(produto);
    }

    /// <summary>
    /// Retorna a lista de produtos adicionados ao banco de dados
    /// </summary>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso a requisição seja feita com sucesso</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IEnumerable<ReadProdutoDTO> ListaProdutos()
    {
        return Mapper.Map<List<ReadProdutoDTO>>(Context.Produtos.ToList());
    }


    /// <summary>
    /// Retorna um produto com o indice escolhido que está no banco de dados
    /// </summary>
    /// <param name="id"> inteiro usado para buscar o produto com esse indice</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso a requisição seja feita com sucesso</response>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult BuscaProdutoPorId(int id)
    {
        var produto = Context.Produtos.FirstOrDefault(produto=>produto.Id== id);
        if (produto is null) return NotFound();
        var produtodto = Mapper.Map<Produto>(produto);
        return Ok(produto);
    }


    /// <summary>
    /// Atualiza um produto do banco de dados
    /// </summary>
    /// <param name="id"> inteiro usado para buscar o produto com esse indice</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso a requisição seja feita com sucesso</response>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult AtualizaProduto(int id, [FromBody] UpdateProdutoDTO produtoDTO)
    {
        Produto produto = Context.Produtos.FirstOrDefault(p => p.Id == id);
        if (produto is null) return NotFound();

        Mapper.Map(produto, produtoDTO);
        Context.SaveChanges();
        return Ok(produto);
    }

    /// <summary>
    /// Atualiza um produto do banco de dados de forma parcial
    /// </summary>
    /// <param name="id"> inteiro usado para buscar o produto com esse indice</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso a requisição seja feita com sucesso</response>
    [HttpPatch("{id}")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult AtualizaProdutoParcial(int id, JsonPatchDocument<UpdateProdutoDTO>patch)
    {
        var produto = Context.Produtos.FirstOrDefault(p => p.Id == id);
        if (produto is null) return NotFound();
        
        var produtoUpdate = Mapper.Map<UpdateProdutoDTO>(produto);
        patch.ApplyTo(produtoUpdate,ModelState);
        
        if (!TryValidateModel(produtoUpdate)) return ValidationProblem(ModelState);

        Mapper.Map(produtoUpdate, produto);
        Context.SaveChanges();
        return NoContent();

    }

    /// <summary>
    /// Remove o produto do banco de dados
    /// </summary>
    /// <param name="id"> inteiro usado para buscar o produto com esse indice</param>
    /// <returns>IActionResult</returns>
    /// <response code="204">Caso a requisição seja feita com sucesso</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult DeletaProduto(int id)
    {
        var produto = Context.Produtos.FirstOrDefault(p=>p.Id==id);
        if (produto is null) return NotFound();
        Context.Remove(produto);
        Context.SaveChanges();
        return NoContent();
    }

}
