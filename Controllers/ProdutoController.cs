using AutoMapper;
using Desafio_IBID.Data;
using Desafio_IBID.Data.DTOs;
using Desafio_IBID.Models;
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

    [HttpPost]
    public IActionResult AdicionaProduto(CreateProdutoDTO produtoDTO)
    {
        var produto = Mapper.Map<Produto>(produtoDTO);
        Context.Produtos.Add(produto);
        Context.SaveChanges();
        return Ok(produto);
    }

    [HttpGet]
    public IEnumerable<ReadProdutoDTO> ListaProdutos()
    {
        return Mapper.Map<List<ReadProdutoDTO>>(Context.Produtos.ToList());
    }

    [HttpGet("{id}")]
    public IActionResult BuscaProdutoPorId(int id)
    {
        var produto = Context.Produtos.FirstOrDefault(produto=>produto.Id== id);
        if (produto is null) return NotFound();
        var produtodto = Mapper.Map<Produto>(produto);
        return Ok(produto);
    }

    [HttpPut]
    public 

}
