using System.Reflection.Metadata.Ecma335;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var Produtos = new List<Produto>
{
    new Produto { Id = 1, Nome = "Produto A", Preco = 10.0m },
    new Produto { Id = 2, Nome = "Produto B", Preco = 20.0m },
    new Produto { Id = 3, Nome = "Produto C", Preco = 30.0m },
    new Produto { Id = 4, Nome = "Perfume", Preco = 180.0m }
};

/*
------------GETS----------------
*/

app.MapGet("/produtos", () =>
{
    return Produtos;
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


app.Run();

class Produto
{
    public required int Id { get; set; }
    public required string  Nome { get; set; }
    public decimal Preco { get; set; }
}

// dto para realizar atualizações via patch
public class ProdutoPatchDto
{
    public string ? Nome { get; set; }
    public decimal ? Preco { get; set; }
}