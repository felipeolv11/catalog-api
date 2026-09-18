using catalog_api.Context;
using catalog_api.Models;
using catalog_api.Pagination;
using catalog_api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace catalog_api.Repositories;

public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
{
    public CategoriaRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IPagedList<Categoria>> GetCategoriasAsync(CategoriasParameters categoriasParams)
    {
        var categorias = await GetAllAsync();

        var categoriasOrdenadas = categorias.OrderBy(c => c.CategoriaId).AsQueryable();

        var resultado = await categoriasOrdenadas.ToPagedListAsync(categoriasParams.pageNumber, categoriasParams.PageSize);

        return resultado;
    }

    public async Task<IPagedList<Categoria>> GetCategoriasFiltroNomeAsync(CategoriasFiltroNome categoriasParams)
    {
        var categorias = await GetAllAsync();

        if (!string.IsNullOrEmpty(categoriasParams.Nome))
        {
            categorias = categorias.Where(c => c.Nome.Contains(categoriasParams.Nome));
        }

        var categoriasFiltradas = await categorias.ToPagedListAsync(categoriasParams.pageNumber, categoriasParams.PageSize);

        return categoriasFiltradas;
    }
}
