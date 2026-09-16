using catalog_api.Context;
using catalog_api.Models;
using catalog_api.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace catalog_api.Controllers;

[Route("[controller]")]
[ApiController]
public class ProdutosController : ControllerBase
{
    private readonly IUnitOfWork _uow;

    public ProdutosController(IUnitOfWork uow)
    {
        _uow = uow;
    }

    [HttpGet("Categoria/{id}")]
    public ActionResult <IEnumerable<Produto>> GetProdutosPorCategoria(int id)
    {
        var produtos = _uow.ProdutoRepository.GetProdutosPorCategoria(id);

        if (produtos is null)
            return NotFound();

        return Ok(produtos);
    }

    [HttpGet]
    public ActionResult<IEnumerable<Produto>> Get()
    {
        var produtos = _uow.ProdutoRepository.GetAll();

        if (produtos is null)
            return NotFound();

        return Ok(produtos);
    }

    [HttpGet("{id:int}", Name = "ObterProduto")]
    public ActionResult<Produto> Get(int id)
    {
        var produto = _uow.ProdutoRepository.Get(p => p.ProdutoId == id);

        if (produto is null)
            return NotFound();

        return Ok(produto);
    }

    [HttpPost]
    public ActionResult Post(Produto produto)
    {
        if (produto is null)
            return BadRequest();

        var produtoCriado = _uow.ProdutoRepository.Create(produto);
        _uow.Commit();

        return new CreatedAtRouteResult("ObterProduto",
            new { id = produto.ProdutoId }, produto);
    }

    [HttpPut("{id:int}")]
    public ActionResult Put(int id, Produto produto)
    {
        if (id != produto.ProdutoId)
            return BadRequest();

        var produtoAtualizado = _uow.ProdutoRepository.Update(produto);
        _uow.Commit();

        return Ok(produtoAtualizado);
    }

    [HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {
        var produto = _uow.ProdutoRepository.Get(p => p.ProdutoId == id);

        if (produto is null)
            return NotFound();

        var produtoExcluido = _uow.ProdutoRepository.Delete(produto);
        _uow.Commit();

        return Ok(produtoExcluido);
    }
}
