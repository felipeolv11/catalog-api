using catalog_api.Context;
using catalog_api.Models;
using catalog_api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace catalog_api.Repositories;

public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
{
    public CategoriaRepository(AppDbContext context) : base(context)
    {
    }
}
