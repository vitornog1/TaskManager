# SDD — Especificação Técnica do TaskManager

## 1. Identificação

- **Projeto:** TaskManager
- **Tipo:** Projeto acadêmico individual
- **Tecnologia principal:** C# / .NET 10
- **Framework:** ASP.NET Core Web API
- **Banco de dados:** SQLite
- **ORM:** Entity Framework Core
- **Testes:** xUnit
- **Contêineres:** Docker e Docker Compose
- **Repositório:** https://github.com/vitornog1/TaskManager
- **Release:** [v1.0.0](https://github.com/vitornog1/TaskManager/releases/tag/v1.0.0)

## 2. Descrição do problema

O TaskManager é uma API REST desenvolvida para demonstrar uma solução simples de gerenciamento de tarefas.

O sistema permite cadastrar, consultar, atualizar, concluir e excluir tarefas, utilizando persistência em banco de dados SQLite.

O projeto tem finalidade acadêmica e foi desenvolvido individualmente para aplicar conceitos de desenvolvimento de software, persistência de dados, testes automatizados, controle de versão, conteinerização e documentação técnica.

## 3. Objetivo

Disponibilizar operações de gerenciamento de tarefas por meio de uma API REST, com persistência de dados e testes automatizados das principais funcionalidades.

## 4. Escopo

O sistema contempla:

- Cadastro de tarefas;
- Listagem de tarefas;
- Consulta de tarefa por identificador;
- Atualização de tarefa;
- Conclusão de tarefa;
- Exclusão de tarefa;
- Persistência utilizando SQLite e Entity Framework Core;
- Testes automatizados com xUnit;
- Execução da aplicação por meio de Docker e Docker Compose.

Não fazem parte do escopo implementado:

- Autenticação de usuários;
- Controle de permissões;
- Interface web;
- Aplicativo mobile;
- Notificações;
- Integrações externas.

## 5. Requisitos funcionais

### RF01 — Criar tarefa

Permitir o cadastro de uma tarefa informando título e descrição.

O título não pode estar vazio. Após a criação, a tarefa recebe um identificador, inicia como não concluída e registra a data de criação.

### RF02 — Listar tarefas

Permitir a consulta das tarefas cadastradas, ordenadas pelo identificador.

### RF03 — Buscar tarefa por ID

Permitir consultar uma tarefa utilizando seu identificador.

### RF04 — Atualizar tarefa

Permitir alterar o título e a descrição de uma tarefa existente. O título não pode estar vazio.

### RF05 — Concluir tarefa

Permitir marcar uma tarefa existente como concluída.

### RF06 — Excluir tarefa

Permitir excluir uma tarefa existente.

### RF07 — Tratar tarefa inexistente

Nas operações de consulta, atualização, conclusão e exclusão, retornar HTTP 404 quando a tarefa solicitada não existir.

## 6. Requisitos não funcionais

- **RNF01 — Plataforma:** utilizar .NET 10.
- **RNF02 — Linguagem:** utilizar C#.
- **RNF03 — Persistência:** utilizar SQLite com Entity Framework Core.
- **RNF04 — Testabilidade:** possuir testes automatizados das principais operações.
- **RNF05 — Versionamento:** manter o código versionado com Git e hospedado no GitHub.
- **RNF06 — Documentação:** fornecer instruções para instalação, execução e testes.
- **RNF07 — Conteinerização:** disponibilizar configuração de execução por Docker e Docker Compose.

## 7. Regras de negócio

- **RN01 — Identificação:** cada tarefa possui um identificador único gerado pela persistência.
- **RN02 — Estado inicial:** uma tarefa recém-criada é definida como não concluída.
- **RN03 — Conclusão:** a operação de conclusão altera o campo `Concluida` para `true`.
- **RN04 — Validação do título:** títulos vazios ou compostos apenas por espaços são rejeitados na criação e atualização.
- **RN05 — Tarefa inexistente:** operações sobre identificadores sem correspondência retornam HTTP 404.

## 8. Modelo de dados

A entidade principal é `Tarefa`, localizada em `TaskManager.API/Models/Tarefa.cs`.

| Campo | Tipo | Descrição |
|---|---|---|
| `Id` | `int` | Identificador da tarefa |
| `Titulo` | `string` | Título da tarefa |
| `Descricao` | `string` | Descrição da tarefa |
| `Concluida` | `bool` | Indica se a tarefa foi concluída |
| `DataCriacao` | `DateTime` | Data e hora de criação |

Na operação de criação, a aplicação define `Concluida` como `false` e atribui `DateTime.UtcNow` a `DataCriacao`.

## 9. Arquitetura e componentes

O projeto utiliza uma arquitetura simples, com separação entre API, modelo, acesso a dados e testes automatizados.

### Model

Arquivo: `TaskManager.API/Models/Tarefa.cs`

Representa os dados de uma tarefa.

### Data

Arquivo: `TaskManager.API/Data/AppDbContext.cs`

Define o contexto do Entity Framework Core e disponibiliza o conjunto de tarefas por meio de `DbSet<Tarefa>`.

### Controller

Arquivo: `TaskManager.API/Controllers/TarefasController.cs`

Recebe as requisições HTTP e executa as operações de gerenciamento de tarefas.

### Inicialização

Arquivo: `TaskManager.API/Program.cs`

Configura os controllers, o Entity Framework Core, o SQLite e o OpenAPI. Durante a inicialização, executa `Database.Migrate()` para aplicar as migrations pendentes.

O mapeamento OpenAPI é habilitado quando a aplicação está no ambiente de desenvolvimento.

### Migrations

Diretório: `TaskManager.API/Migrations/`

Contém as migrações do Entity Framework Core utilizadas para controlar a estrutura do banco de dados.

### Testes

Diretório: `TaskManager.Tests/`

Contém os testes automatizados e a fábrica de contexto utilizada para preparar o ambiente de teste.

## 10. API e contratos HTTP

A rota base do controller é `/api/tarefas`.

### Criar tarefa

- **Método:** `POST`
- **Endpoint:** `/api/tarefas`
- **Entrada:**

```json
{
  "titulo": "Estudar C#",
  "descricao": "Revisar conceitos de C# e .NET"
}
```

- **Sucesso:** HTTP 201 — Created.
- **Validação:** HTTP 400 — Bad Request quando o título estiver vazio.

A resposta de sucesso contém os dados da tarefa criada e a localização do recurso.

### Listar tarefas

- **Método:** `GET`
- **Endpoint:** `/api/tarefas`
- **Sucesso:** HTTP 200 — OK.

Retorna a lista de tarefas ordenada pelo identificador.

### Buscar tarefa por ID

- **Método:** `GET`
- **Endpoint:** `/api/tarefas/{id}`
- **Sucesso:** HTTP 200 — OK.
- **Tarefa inexistente:** HTTP 404 — Not Found.

### Atualizar tarefa

- **Método:** `PUT`
- **Endpoint:** `/api/tarefas/{id}`
- **Entrada:**

```json
{
  "titulo": "Estudar C# atualizado",
  "descricao": "Revisar conceitos de C# e .NET 10",
  "concluida": false
}
```

- **Sucesso:** HTTP 200 — OK.
- **Tarefa inexistente:** HTTP 404 — Not Found.
- **Título vazio:** HTTP 400 — Bad Request.

A implementação atualiza o título e a descrição da tarefa existente.

### Concluir tarefa

- **Método:** `PATCH`
- **Endpoint:** `/api/tarefas/{id}/concluir`
- **Sucesso:** HTTP 200 — OK.
- **Tarefa inexistente:** HTTP 404 — Not Found.

A operação define o campo `Concluida` como `true`.

### Excluir tarefa

- **Método:** `DELETE`
- **Endpoint:** `/api/tarefas/{id}`
- **Sucesso:** HTTP 204 — No Content.
- **Tarefa inexistente:** HTTP 404 — Not Found.

A operação remove a tarefa da persistência.

## 11. Persistência de dados

A aplicação utiliza SQLite como banco de dados e Entity Framework Core como ORM.

A configuração da conexão está em `TaskManager.API/appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=taskmanager.db"
  }
}
```

O contexto de dados é implementado em `TaskManager.API/Data/AppDbContext.cs`.

A aplicação executa as migrations pendentes durante a inicialização.

A conexão utiliza o nome relativo `taskmanager.db`. O caminho efetivo do arquivo depende do diretório de trabalho da aplicação e da configuração do ambiente.

## 12. Docker e execução reproduzível

O projeto possui um `Dockerfile` com duas etapas:

1. **Build:** utiliza a imagem do SDK do .NET 10 para restaurar dependências e publicar a aplicação em modo Release.
2. **Execução:** utiliza a imagem ASP.NET 10 para executar `TaskManager.API.dll`.

O container expõe a porta `8080`.

O arquivo `docker-compose.yml` define o serviço `taskmanager-api`, publica a porta `8080` do container na porta `8080` do host e declara o volume nomeado `taskmanager-data`, montado em `/app/data`.

O serviço utiliza a variável `ASPNETCORE_ENVIRONMENT=Production`.

**Observação:** a connection string atual utiliza `Data Source=taskmanager.db`, sem caminho explícito para `/app/data`. Portanto, a persistência do arquivo SQLite no volume nomeado precisa ser validada no ambiente de execução antes de ser considerada garantida.

### Executar com Docker Compose

Na raiz do repositório:

```powershell
docker compose up --build
```

A API fica disponível localmente em:

```text
http://localhost:8080/api/tarefas
```

Para encerrar os containers, utilize `Ctrl + C` e, se necessário, execute:

```powershell
docker compose down
```

## 13. Testes automatizados

Os testes utilizam xUnit e estão localizados em `TaskManager.Tests/TarefasControllerTests.cs`.

A classe `TaskManager.Tests/TestDbContextFactory.cs` auxilia na criação do contexto utilizado nos testes.

A suíte contém os seguintes casos:

| Operação | Teste |
|---|---|
| Criar | `Criar_DeveCriarTarefaComSucesso` |
| Listar | `Listar_DeveRetornarTodasAsTarefas` |
| Buscar existente | `BuscarPorId_DeveRetornarTarefaExistente` |
| Buscar inexistente | `BuscarPorId_DeveRetornar404QuandoNaoEncontrar` |
| Atualizar | `Atualizar_DeveAtualizarTarefaComSucesso` |
| Atualizar inexistente | `Atualizar_DeveRetornar404QuandoTarefaNaoExistir` |
| Concluir | `Concluir_DeveMarcarTarefaComoConcluida` |
| Concluir inexistente | `Concluir_DeveRetornar404QuandoTarefaNaoExistir` |
| Excluir | `Excluir_DeveExcluirTarefaComSucesso` |
| Excluir inexistente | `Excluir_DeveRetornar404QuandoTarefaNaoExistir` |

A última execução registrada apresentou:

- **Total:** 10 testes;
- **Aprovados:** 10;
- **Falhas:** 0;
- **Ignorados:** 0.

Para repetir os testes no ambiente local:

```powershell
dotnet test --logger "console;verbosity=normal"
```

## 14. Cobertura de testes

A cobertura pode ser coletada utilizando o coletor XPlat Code Coverage:

```powershell
dotnet test --collect:"XPlat Code Coverage"
```

O comando gera um arquivo de cobertura no diretório de resultados de teste, normalmente dentro de `TestResults`.

A cobertura pode ser utilizada para identificar quais partes do código foram exercitadas pelos testes.

O percentual de cobertura deve ser registrado a partir do relatório efetivamente gerado. A quantidade de testes aprovados, isoladamente, não representa o percentual de cobertura do código.

## 15. Execução local

Com o SDK do .NET 10 instalado, os comandos básicos são:

Restaurar as dependências:

```powershell
dotnet restore
```

Compilar a solução:

```powershell
dotnet build
```

Executar os testes:

```powershell
dotnet test
```

Executar a API:

```powershell
dotnet run --project .\TaskManager.API
```

A URL e a porta efetivas da execução local dependem das configurações de inicialização do projeto.

## 16. Versionamento e release

O código-fonte é hospedado no GitHub:

https://github.com/vitornog1/TaskManager

A versão `v1.0.0` foi publicada como release oficial:

https://github.com/vitornog1/TaskManager/releases/tag/v1.0.0

O projeto utiliza Git para controle de versão e GitHub para hospedagem do código e das releases.

O desenvolvimento foi realizado individualmente, com adaptação dos requisitos originalmente voltados ao trabalho em equipe.

## 17. Decisões técnicas e limitações

As principais decisões técnicas foram:

- Utilização de C# e .NET 10;
- Utilização de ASP.NET Core Web API;
- Separação entre controller, modelo e contexto de dados;
- Utilização de Entity Framework Core;
- Utilização de SQLite;
- Utilização de xUnit para testes automatizados;
- Utilização de Docker e Docker Compose;
- Utilização de Git e GitHub para versionamento.

As limitações do sistema incluem a ausência de autenticação, controle de permissões, interface web, aplicativo mobile, notificações e integrações externas.

O escopo reduzido é compatível com a finalidade acadêmica do projeto.

## 18. Considerações finais

O TaskManager implementa operações básicas de gerenciamento de tarefas por meio de uma API REST, com persistência em SQLite, migrations do Entity Framework Core, testes automatizados e configuração de execução em Docker.

Esta especificação descreve a estrutura e o comportamento identificados no código-fonte e nas configurações do projeto. Os resultados de testes, cobertura e execução devem ser atualizados quando novas validações forem realizadas.
