namespace MinimalAPI.Models;

public class Produto
{
    public required int Id { get; set; }
    public required string  Nome { get; set; }
    public decimal Preco { get; set; }
}