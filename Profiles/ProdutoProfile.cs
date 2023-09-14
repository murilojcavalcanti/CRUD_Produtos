using AutoMapper;
using Desafio_IBID.Data.DTOs;
using Desafio_IBID.Models;

namespace Desafio_IBID.Profiles;

public class ProdutoProfile:Profile
{
    public ProdutoProfile()
    {
        CreateMap<CreateProdutoDTO, Produto>();
        CreateMap<Produto,ReadProdutoDTO>();

    }
}
