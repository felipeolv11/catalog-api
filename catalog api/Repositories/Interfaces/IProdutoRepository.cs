using catalog_api.Models;
using catalog_api.Pagination;

namespace catalog_api.Repositories.Interfaces;

public interface IProdutoRepository : IRepository<Produto>
{
    PagedList<Produto> GetProdutos(ProdutosParameters produtosParams);
    IEnumerable<Produto> GetProdutosPorCategoria(int id);
}
