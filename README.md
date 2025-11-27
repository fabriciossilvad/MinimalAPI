# MinimalAPI -- CRUD de Produtos

Este projeto é uma **Minimal API em .NET** criada para demonstrar
operações básicas de CRUD utilizando uma lista em memória.\
Inclui suporte a **Swagger**, **OpenAPI**, e rotas com `GET`, `POST`,
`PUT` e `PATCH`.

------------------------------------------------------------------------

## 🚀 Tecnologias utilizadas

-   **.NET 9**
-   **Minimal API**
-   **Swagger / OpenAPI**
-   **C#**

------------------------------------------------------------------------

## 📌 Como executar o projeto

1.  Clone o repositório:

    ``` bash
    git clone <url-do-repo>
    ```

2.  Navegue até a pasta do projeto:

    ``` bash
    cd MinimalAPI/backend
    ```

3.  Execute a API:

    ``` bash
    dotnet run
    ```

4.  Acesse no navegador:

    -   Swagger UI:\
        **https://localhost:5168/swagger**

    -   Endpoints manuais:\
        **https://localhost:5168/produtos**

------------------------------------------------------------------------

## 📚 Endpoints da API

### 🔹 **GET /produtos**

Retorna a lista completa de produtos.

### 🔹 **GET /produtos/{id}**

Retorna um produto pelo ID.

### 🔹 **GET /produtos/{nome}**

Filtra produtos contendo o nome informado (case-insensitive).

------------------------------------------------------------------------

## 🟢 **POST /produtos**

Cria um novo produto.

### Exemplo de body:

``` json
{
  "id": 5,
  "nome": "Caderno",
  "preco": 15.5
}
```

------------------------------------------------------------------------

## 🟡 **PUT /produtos/{id}**

Atualiza **todos** os dados de um produto existente.

### Exemplo:

``` json
{
  "nome": "Produto Atualizado",
  "preco": 99.9
}
```

------------------------------------------------------------------------

## 🟠 **PATCH /produtos/{id}**

Atualiza parcialmente um produto (somente os campos enviados).

### DTO usado:

``` json
{
  "nome": "Novo nome",
  "preco": 50.0
}
```

Os campos são opcionais (`null` é ignorado).

------------------------------------------------------------------------

## 🧪 Objetos do sistema

### Produto

``` csharp
class Produto
{
    public required int Id { get; set; }
    public required string Nome { get; set; }
    public decimal Preco { get; set; }
}
```

### ProdutoPatchDto

``` csharp
public class ProdutoPatchDto
{
    public string? Nome { get; set; }
    public decimal? Preco { get; set; }
}
```

------------------------------------------------------------------------

## 📂 Estrutura atual do projeto

    MinimalAPI/
    └── backend/
        ├── Properties/
        ├── Program.cs
        ├── backend.csproj
        ├── appsettings.json
        ├── appsettings.Development.json (ignorado)
        ├── bin/ (ignorado)
        ├── obj/ (ignorado)
        └── .gitignore

------------------------------------------------------------------------

## 📄 Licença

Este projeto é de uso livre para estudos e testes.

------------------------------------------------------------------------

## 🤝 Contribuições

Sinta-se à vontade para abrir Issues ou Pull Requests.\
Sugestões são sempre bem-vindas! 🙌
