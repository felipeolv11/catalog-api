using catalog_api.Context;
using catalog_api.Models;
using Microsoft.EntityFrameworkCore;

namespace catalog_api.Repositories;

public class ProdutoRepository : IProdutoRepository
{
    private readonly AppDbContext _context;

    public IEnumerable<Produto> GetProdutos()
    {
        return _context.Produtos.AsNoTracking().ToList();
    }

    public Produto GetProduto(int id)
    {
        return _context.Produtos.AsNoTracking().FirstOrDefault(p => p.ProdutoId == id);
    }

    public Produto Create(Produto produto)
    {
        if (produto is null)
            throw new ArgumentNullException(nameof(produto));

        _context.Produtos.Add(produto);
        _context.SaveChanges();

        return produto;
    }

    public Produto Update(Produto produto)
    {
        if (produto is null)
            throw new ArgumentNullException(nameof(produto));

        _context.Entry(produto).State = EntityState.Modified;
        _context.SaveChanges();

        return produto;
    }

    public Produto Delete(int id)
    {
        var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);

        if (produto is null)
            throw new ArgumentNullException(nameof(produto));

        _context.Produtos.Remove(produto);
        _context.SaveChanges();

        return produto;
    }
}
