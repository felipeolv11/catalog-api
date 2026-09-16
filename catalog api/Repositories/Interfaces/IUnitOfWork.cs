namespace catalog_api.Repositories.Interfaces;

public interface IUnitOfWork
{
    IProdutoRepository ProdutoRepository { get; }
    ICategoriaRepository CategoriaRepository { get; }
    void Commit();
}
