using catalog_api.Models;
using catalog_api.Pagination;

namespace catalog_api.Repositories.Interfaces;

public interface ICategoriaRepository : IRepository<Categoria>
{
    PagedList<Categoria> GetCategorias(CategoriasParameters categoriasParams);
}
