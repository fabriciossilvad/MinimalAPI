
using MinimalAPI.Models;
using MinimalAPI.DTOs;
using MinimalAPI.Services;

namespace MinimalAPI.EndPoints;

/*
------------GETS----------------
*/

app.MapGet("/produtos", ( ProdutoServices ProdutoServices) =>
{
    return ProdutoServices.GetTodosProdutos();
});

app.MapGet("/produtos/{id:int}", (int id) =>
{
    var produto = Produtos.FirstOrDefault(p => p.Id == id);
    
    return produto != null
    ? Results.Ok(produto)
    : Results.NotFound("Produto não encontrado");
});

app.MapGet("/produtos/{nome}", (String nome) =>
{
    var produto = Produtos.Where(x => x.Nome.Contains(nome, StringComparison.OrdinalIgnoreCase)).ToList();

    return produto != null 
    ? Results.Ok(produto)
    : Results.NotFound("Produto não encontrado");
});


/*
-------------POSTS----------------
*/


app.MapPost("/produtos", (Produto novoProduto) =>
{
    if (Produtos.Any(p => p.Id == novoProduto.Id))
        return Results.BadRequest("Produto com esse ID já existe");
    
    Produtos.Add(novoProduto);

    return Results.Created($"/produto/{novoProduto.Id}", novoProduto);
});

/*
-------------PUTS----------------
*/

app.MapPut(("/produtos/{id:int}"), (int id, Produto produtoAtualizado) =>
{
    var prod = Produtos.FirstOrDefault(p => p.Id == id);
    if (prod is null)
    {
        return Results.NotFound($"Produto de id {id} não está cadastrado ainda.");
    }
    prod.Nome = produtoAtualizado.Nome;
    prod.Preco = produtoAtualizado.Preco;

    return Results.Ok(prod);
});

/*
-------------PATCH----------------
*/

app.MapPatch(("/produtos/{id:int}"), (int id, ProdutoPatchDto dto) =>
{
    var prod = Produtos.FirstOrDefault(p => p.Id == id);
    if (prod is not null)
    {
        prod.Nome = dto.Nome ?? prod.Nome;
        prod.Preco = dto.Preco ?? prod.Preco;
        return Results.Ok(prod);
    }
    return Results.NotFound($"Produto de id {id} não está cadastrado ainda");
});