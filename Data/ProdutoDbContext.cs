using Desafio_IBID.Models;
using Microsoft.EntityFrameworkCore;

namespace Desafio_IBID.Data;

public class ProdutoDbContext:DbContext
{
    public ProdutoDbContext(DbContextOptions<ProdutoDbContext> opts): base(opts)
    {
        
    }

    public DbSet<Produto> Produtos { get; set; }

}
