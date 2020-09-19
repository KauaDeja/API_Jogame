# [06 - ORM - Mapeamento objeto-relacional](https://www.notion.so/06-ORM-Mapeamento-objeto-relacional-8b48105fbf92442b90672c3ce555315d)
Capacidades: 

8. Estabelecer envio de notificações entre cliente e servidor por meio de aplicação web
9. Desenvolver API (web services) para integração de dados entre plataformas
10. Desenvolver sistemas web de acordo com as regras de negócio estabelecidas

Tipo: Formativa

Nesta aula vamos abordar o assunto de Mapeamento de Objetos Relacionais

Nesta atividade faça os mesmos exemplos dados em aula.

[sprint2-api-03-ef.pdf](https://s3-us-west-2.amazonaws.com/secure.notion-static.com/e40c1dbb-8c40-4a5d-abee-7f5124d958df/sprint2-api-03-ef.pdf)

- [ ]  ORM - Definição
- [ ]  Documentação EF Core
- [ ]  Abordagens
    - [ ]  Code First
    - [ ]  Database First
- [ ]  Projeto - Pedidos (Code First)

## Projeto - Pedidos (Code First)

- [ ]  Instalar pacotes:
    - [ ]  Entity Framework Core
    - [ ]  Microsoft.EntityFrameworkCore.Tools
    - [ ]  Microsoft.EntityFrameworkCore.Design
    - [ ]  Microsoft.EntityFrameworkCore.SqlServer
- [ ]  Criar Domains
    - [ ]  Produto

    ```csharp
    public class Produto
        {
    				[Key]
            public int IdProduto { get; set; }
            public string NomeProduto { get; set; }
            public float Preco { get; set; }

            public List<PedidoItem> PedidoItem { get; set; }
        }
    ```

    - [ ]  Pedido

    ```csharp
    public class Pedido
        {
    				[Key]
            public int IdPedido { get; set; }
            public string Status { get; set; }
            public DateTime OrderDate { get; set; }

            public List<PedidoItem> PedidoItem { get; set; }
        }
    ```

    - [ ]  PedidoItem

    ```csharp
    public class PedidoItem
        {
    				[Key]
            public int IDPedidoItem { get; set; }
            public int IdPedido { get; set; }
            public int IdProduto { get; set; }
            public int Quantidade { get; set; }

            public Pedido Pedido { get; set; }
            public Produto Produto { get; set; }
        }
    ```

    - [ ]  Criar pasta Contexts
    - [ ]  Criar classe PedidoContext.cs , aplicando a herança de Dbcontext

    ```csharp
    public class PedidoContext : DbContext
        {
            public DbSet<PedidoItem> PedidoItem { get; set; }
            public DbSet<Pedido> Pedido { get; set; }
            public DbSet<Produto> Produto { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer(@"Data Source=N-1S-DEV-16\SQLEXPRESS;Initial Catalog=loja;User ID=sa;Password=sa132");
            }
        }
    ```

    - [ ]  Instalar o ef de forma global (para acessar linha de comando)

        ```bash
        dotnet tool install --global dotnet-ef
        ```

    - [ ]  Testamos para ver se instalou tudo corretamente:

        ```bash
        dotnet ef
        ```

        ![https://s3-us-west-2.amazonaws.com/secure.notion-static.com/8ca06351-130a-4122-9590-93c7a20fe8df/Untitled.png](https://s3-us-west-2.amazonaws.com/secure.notion-static.com/8ca06351-130a-4122-9590-93c7a20fe8df/Untitled.png)

    - [ ]  Adicionamos a string de conexão no appsetting.json

        ```bash
        {
          "ConnectionStrings": {
            "DefaultConnection": "Data Source=N-1S-DEV-16\\SQLEXPRESS;Initial Catalog=loja;User ID=sa;Password=sa132"
          },
        ```

    - [ ]  Criamos o diretório Migrations com os devidos scripts que vão gerar o banco:

        ```bash
        dotnet ef migrations add InitialCreate
        ```

    - [ ]  Criamos o banco efetivamente:

        ```bash
        dotnet ef database update
        
        # 07 - ORM - EF Core - Code First - Repository
        
        

6. Utilizar interações com base de dados para desenvolvimento de sistemas web

8. Estabelecer envio de notificações entre cliente e
servidor por meio de aplicação web
9. Desenvolver API (web services) para integração de
dados entre plataformas
10. Desenvolver sistemas web de acordo com as regras
de negócio estabelecidas

Tipo: Formativa

- [x]  Refatorar Classes
    - [x]  Criar Classe Base com Id

    ```jsx
    public class BaseDomain
    {
            public Guid Id { get; set; }

            public BaseDomain()
            {
                Id = Guid.NewGuid();
            }
    }
    ```

- [x]  Criar pasta interfaces
    - [x]  Criar interface IProdutoRepository.cs

    ![https://s3-us-west-2.amazonaws.com/secure.notion-static.com/b988a126-f67f-4538-95c6-76037b827458/Untitled.png](https://s3-us-west-2.amazonaws.com/secure.notion-static.com/b988a126-f67f-4538-95c6-76037b827458/Untitled.png)

- [x]  Criar Pasta Repositories
    - [x]  Criar class ProdutoRepository
    - [x]  Herdar interface IProduto e IDisposable
        - [x]  ProdutoRepository : IProduto
    - [x]  Criar objeto referente ao contexto e instanciar no construtor

    ![https://s3-us-west-2.amazonaws.com/secure.notion-static.com/f3aa4a20-a850-4bb9-b405-ee633fbad2de/Untitled.png](https://s3-us-west-2.amazonaws.com/secure.notion-static.com/f3aa4a20-a850-4bb9-b405-ee633fbad2de/Untitled.png)

    - [x]  Implementar Método Listar

    ![https://s3-us-west-2.amazonaws.com/secure.notion-static.com/08380b11-2f2c-4c54-b72b-0bc8990ef09d/Untitled.png](https://s3-us-west-2.amazonaws.com/secure.notion-static.com/08380b11-2f2c-4c54-b72b-0bc8990ef09d/Untitled.png)

    - [x]  Implementar método BuscarPorId

    ![https://s3-us-west-2.amazonaws.com/secure.notion-static.com/ae39997e-42bd-4565-a413-0d03edcaf5a0/Untitled.png](https://s3-us-west-2.amazonaws.com/secure.notion-static.com/ae39997e-42bd-4565-a413-0d03edcaf5a0/Untitled.png)

    - [x]  Implementar método Editar

    ![https://s3-us-west-2.amazonaws.com/secure.notion-static.com/42e4a800-ac0b-41ab-a114-e916564af21f/Untitled.png](https://s3-us-west-2.amazonaws.com/secure.notion-static.com/42e4a800-ac0b-41ab-a114-e916564af21f/Untitled.png)

    - [x]  Implementar Método Excluir

    ![https://s3-us-west-2.amazonaws.com/secure.notion-static.com/6a4a56ec-8780-4338-9fc1-85e4d3fd6bec/Untitled.png](https://s3-us-west-2.amazonaws.com/secure.notion-static.com/6a4a56ec-8780-4338-9fc1-85e4d3fd6bec/Untitled.png)

    - [x]  Implementar método Cadastrar

    ![https://s3-us-west-2.amazonaws.com/secure.notion-static.com/416180ea-201a-4068-b51d-450f46db8dd4/Untitled.png](https://s3-us-west-2.amazonaws.com/secure.notion-static.com/416180ea-201a-4068-b51d-450f46db8dd4/Untitled.png)

    - [x]  Criar Controller - ProdutosController
    - [x]  Criar propriedade IProdutoRepository e instanciar no construtor

    ![https://s3-us-west-2.amazonaws.com/secure.notion-static.com/6272cd20-b2be-40c0-8c9e-ba4790d44f55/Untitled.png](https://s3-us-west-2.amazonaws.com/secure.notion-static.com/6272cd20-b2be-40c0-8c9e-ba4790d44f55/Untitled.png)

    - [x]  Implementar Métodos Get, Get/Id, Post, Put, Delete
        ```
