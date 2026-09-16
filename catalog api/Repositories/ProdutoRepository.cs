using catalog_api.Context;
using catalog_api.Models;
using catalog_api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace catalog_api.Repositories;

public class ProdutoRepository : Repository<Produto>, IProdutoRepository
{
    public ProdutoRepository(AppDbContext context) : base(context)
    {
    }

    public IEnumerable<Produto> GetProdutosPorCategoria(int id)
    {
        return GetAll().Where(c => c.CategoriaId == id);
    }
}
