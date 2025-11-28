using MinimalAPI.DTOs;
using MinimalAPI.Models;
namespace MinimalAPI.Services;

public class ProdutoServices
{
    private List<Produto> ListarProdutos = new List<Produto>
    {
      new Produto { Id = 1, Nome = "Produto A", Preco = 10.0m },
      new Produto { Id = 2, Nome = "Produto B", Preco = 20.0m },
      new Produto { Id = 3, Nome = "Produto C", Preco = 30.0m },
      new Produto { Id = 4, Nome = "Perfume", Preco = 180.0m }
    };

    public List<Produto> ? GetTodosProdutos () => ListarProdutos;

    public Produto? BuscarId (int id) => ListarProdutos.FirstOrDefault(p=> p.Id == id);

    public List<Produto> ? BuscarNome (string nome ) => ListarProdutos.Where(p => p.Nome.Contains(nome, StringComparison.OrdinalIgnoreCase)).ToList();
    public Produto ? CriarProduto (Produto p){
      var produto = ListarProdutos.FirstOrDefault(x=> x.Id == p.Id);

      //Verifica a disponibilidade do Id antes de criar um novo produto, para não ter duplicatas.
      if (produto != null)
      {
        return null;
      }
      
      ListarProdutos.Add(p); 
      return p;
            
    } 

    public Produto ? PutProduto (int id, Produto produtoAtualizado){
      var produto = ListarProdutos.FirstOrDefault(p => p.Id == id);
      if(produto is not null){
        produto.Nome = produtoAtualizado.Nome;
        produto.Preco = produtoAtualizado.Preco;
        return produto;
      }
      return null;
    }

    
}