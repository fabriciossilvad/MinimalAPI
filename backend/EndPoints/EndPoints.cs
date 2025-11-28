
using MinimalAPI.Models;
using MinimalAPI.DTOs;
using MinimalAPI.Services;

namespace MinimalAPI.EndPoints;

public static class ProdutoEndPoints
{
  public static void MapProdutosEndPoints( this WebApplication app)
  {
    /*
    ------------GETS----------------
    */

    app.MapGet("/produtos", ( ProdutoServices ps) =>
    {
        return ps.GetTodosProdutos();
    });

    app.MapGet("/produtos/{id:int}", (int id, ProdutoServices ps) =>
    {
        var produto = ps.BuscarId(id);
        return produto != null
        ? Results.Ok(produto)
        : Results.NotFound("Produto não encontrado");
    });

    app.MapGet("/produtos/{nome}", (String nome, ProdutoServices ps) =>
    {
        var produto = ps.BuscarNome(nome);
        return produto != null 
        ? Results.Ok(produto)
        : Results.NotFound("Produto não encontrado");
    });


    /*
    -------------POSTS----------------
    */


    app.MapPost("/produtos", (Produto novoProduto, ProdutoServices ps) =>
    {
        var produtoCriado = ps.CriarProduto(novoProduto);
        return produtoCriado is not null
        ? Results.Created($"/produto/{novoProduto.Id}", novoProduto)
        : Results.BadRequest($"Produto com esse Id já existe!");
    });

    /*
    -------------PUTS----------------
    */

    app.MapPut(("/produtos/{id:int}"), (int id, Produto produtoAtualizado, ProdutoServices ps) =>
    {
        var p = ps.PutProduto(id, produtoAtualizado);
        return p is not null
        ? Results.Ok(p)
        : Results.NotFound($"Produto não encontrado!");
    });

    /*
    -------------PATCH----------------
    */

    
  }
}
