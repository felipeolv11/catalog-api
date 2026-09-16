using catalog_api.Context;
using catalog_api.Models;
using catalog_api.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace catalog_api.Controllers;

[Route("[controller]")]
[ApiController]
public class CategoriasController : ControllerBase
{
    private readonly IUnitOfWork _uow;

    public CategoriasController(IUnitOfWork uow)
    {
        _uow = uow;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Categoria>> Get()
    {
        var categorias = _uow.CategoriaRepository.GetAll();

        if (categorias is null)
            return NotFound();

        return Ok(categorias);
    }

    [HttpGet("{id:int}", Name = "ObterCategoria")]
    public ActionResult<Categoria> Get(int id)
    {
        var categoria = _uow.CategoriaRepository.Get(c => c.CategoriaId == id);

        if (categoria is null)
            return NotFound();

        return Ok(categoria);
    }

    [HttpPost]
    public ActionResult Post(Categoria categoria)
    {
        if (categoria is null)
            return BadRequest();

        var categoriaCriada = _uow.CategoriaRepository.Create(categoria);
        _uow.Commit();

        return new CreatedAtRouteResult("ObterCategoria",
            new { id = categoria.CategoriaId }, categoria);
    }

    [HttpPut("{id:int}")]
    public ActionResult Put(int id, Categoria categoria)
    {
        if (id != categoria.CategoriaId)
            return BadRequest();

        var categoriaAtualizada = _uow.CategoriaRepository.Update(categoria);
        _uow.Commit();

        return Ok(categoriaAtualizada);
    }

    [HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {
        var categoria = _uow.CategoriaRepository.Get(c => c.CategoriaId == id);

        if (categoria is null)
            return NotFound();

        var categoriaExcluida = _uow.CategoriaRepository.Delete(categoria);
        _uow.Commit();

        return Ok(categoriaExcluida);
    }
}
