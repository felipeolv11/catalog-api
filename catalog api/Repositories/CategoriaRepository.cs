using catalog_api.Context;
using catalog_api.Models;
using catalog_api.Pagination;
using catalog_api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace catalog_api.Repositories;

public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
{
    public CategoriaRepository(AppDbContext context) : base(context)
    {
    }

    public PagedList<Categoria> GetCategorias(CategoriasParameters categoriasParams)
    {
        var categorias = GetAll().OrderBy(c => c.CategoriaId).AsQueryable();

        var categoriasOrdenadas = PagedList<Categoria>.ToPagedList(categorias, categoriasParams.pageNumber, categoriasParams.PageSize);

        return categoriasOrdenadas;
    }
}
