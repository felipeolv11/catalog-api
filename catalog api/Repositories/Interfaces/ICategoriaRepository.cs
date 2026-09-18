using catalog_api.Models;
using catalog_api.Pagination;
using X.PagedList;

namespace catalog_api.Repositories.Interfaces;

public interface ICategoriaRepository : IRepository<Categoria>
{
    Task<IPagedList<Categoria>> GetCategoriasAsync(CategoriasParameters categoriasParams);
    Task<IPagedList<Categoria>> GetCategoriasFiltroNomeAsync(CategoriasFiltroNome categoriasParams);
}
