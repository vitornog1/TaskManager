# SDD – Especificação Técnica do TaskManager

## 1. Identificação

**Projeto:** TaskManager  
**Tipo:** Projeto acadêmico individual  
**Tecnologia principal:** C# / .NET 10  
**Banco de dados:** SQLite  
**Testes:** xUnit  

## 2. Descrição do problema

O TaskManager foi desenvolvido para demonstrar uma solução simples de gerenciamento de tarefas por meio de uma API REST.

O sistema permite que tarefas sejam cadastradas, consultadas, atualizadas, concluídas e excluídas.

O projeto possui escopo acadêmico e foi desenvolvido individualmente, com o objetivo de aplicar conceitos de desenvolvimento de software, persistência de dados, testes automatizados, controle de versão e documentação técnica.

## 3. Objetivo

Desenvolver uma API capaz de realizar as principais operações de gerenciamento de tarefas, mantendo os dados persistidos em banco de dados e garantindo o funcionamento das operações por meio de testes automatizados.

## 4. Escopo

O sistema contempla:

- Cadastro de tarefas;
- Listagem de tarefas;
- Consulta de tarefa por identificador;
- Atualização de tarefas;
- Conclusão de tarefas;
- Exclusão de tarefas;
- Persistência utilizando SQLite;
- Testes automatizados das principais operações.

Não fazem parte do escopo:

- Autenticação de usuários;
- Controle de permissões;
- Interface web;
- Aplicativo mobile;
- Notificações;
- Integrações externas.

Essas limitações mantêm o projeto compatível com o objetivo acadêmico da entrega.

## 5. Requisitos Funcionais

### RF01 – Criar tarefa

O sistema deve permitir o cadastro de uma nova tarefa informando título e descrição.

### RF02 – Listar tarefas

O sistema deve permitir a consulta de todas as tarefas cadastradas.

### RF03 – Buscar tarefa por ID

O sistema deve permitir consultar uma tarefa específica utilizando seu identificador.

### RF04 – Atualizar tarefa

O sistema deve permitir alterar os dados de uma tarefa existente.

### RF05 – Concluir tarefa

O sistema deve permitir alterar o estado de uma tarefa para concluída.

### RF06 – Excluir tarefa

O sistema deve permitir excluir uma tarefa existente.

### RF07 – Tratar tarefa inexistente

Quando uma tarefa solicitada não existir, a API deve retornar uma resposta HTTP 404.

## 6. Requisitos Não Funcionais

### RNF01 – Plataforma

A aplicação deve utilizar .NET 10.

### RNF02 – Linguagem

A aplicação deve ser desenvolvida utilizando C#.

### RNF03 – Persistência

Os dados devem ser armazenados utilizando SQLite.

### RNF04 – Testabilidade

As principais operações da aplicação devem possuir testes automatizados.

### RNF05 – Versionamento

O código deve ser versionado utilizando Git e hospedado no GitHub.

### RNF06 – Documentação

O projeto deve possuir documentação suficiente para explicar sua instalação, execução e estrutura.

## 7. Regras de Negócio

### RN01 – Identificação

Cada tarefa deve possuir um identificador único.

### RN02 – Estado inicial

Uma nova tarefa deve ser criada como não concluída.

### RN03 – Conclusão

Uma tarefa pode ter seu estado alterado para concluída por meio da operação de conclusão.

### RN04 – Consulta

A consulta por identificador deve retornar a tarefa quando ela existir.

### RN05 – Tarefa inexistente

Caso o identificador informado não corresponda a uma tarefa cadastrada, a API deve retornar HTTP 404.

## 8. Modelo de dados

A entidade principal do sistema é `Tarefa`.

### Atributos

| Campo | Tipo | Descrição |
|---|---|---|
| Id | int | Identificador da tarefa |
| Titulo | string | Título da tarefa |
| Descricao | string | Descrição da tarefa |
| Concluida | bool | Indica se a tarefa foi concluída |
| DataCriacao | DateTime | Data de criação da tarefa |

## 9. Decomposição em unidades

O projeto foi dividido em unidades com responsabilidades específicas.

### Model

Responsável pela representação dos dados da tarefa.

Arquivo:

```text
TaskManager.API/Models/Tarefa.cs

```text
### Data

Responsável pelo acesso e persistência dos dados utilizando Entity Framework Core e SQLite.

Arquivo:

TaskManager.API/Data/AppDbContext.cs

O AppDbContext representa o contexto do banco de dados e disponibiliza o conjunto de tarefas para operações de consulta, inclusão, atualização e exclusão.

### Controller

Responsável por disponibilizar os endpoints da API REST e executar as operações relacionadas às tarefas.

Arquivo:

TaskManager.API/Controllers/TarefasController.cs

O controller possui as operações de criação, listagem, consulta por identificador, atualização, conclusão e exclusão de tarefas.

### Testes

Responsável pela validação automatizada das principais funcionalidades da aplicação.

Arquivos:

TaskManager.Tests/TarefasControllerTests.cs
TaskManager.Tests/TestDbContextFactory.cs

Os testes utilizam xUnit e um contexto de banco de dados configurado para os testes. Dessa forma, é possível validar as principais operações do controller de forma independente do banco de dados utilizado pela aplicação.

### Migrations

Responsável pelo controle da estrutura do banco de dados por meio das migrações do Entity Framework Core.

Diretório:

TaskManager.API/Migrations/

As migrations registram as alterações da estrutura do banco de dados e permitem a criação e atualização das tabelas utilizadas pela aplicação.

---

## 10. API e contratos

A aplicação disponibiliza uma API REST para realizar as operações de gerenciamento de tarefas.

### Criar tarefa

**Método:** POST

**Endpoint:** `/api/tarefas`

**Entrada:**

```json
{
  "titulo": "Estudar C#",
  "descricao": "Revisar conceitos de C# e .NET"
}

**Resposta esperada:**

HTTP 201 – Created.

A resposta contém os dados da tarefa criada e seu identificador.

### Listar tarefas

**Método:** GET

**Endpoint:** `/api/tarefas`

**Resposta esperada:**

HTTP 200 – OK.

Retorna as tarefas cadastradas no banco de dados.

### Buscar tarefa por ID

**Método:** GET

**Endpoint:** `/api/tarefas/{id}`

**Exemplo:** `/api/tarefas/1`

**Resposta quando encontrada:**

HTTP 200 – OK.

Retorna os dados da tarefa solicitada.

**Resposta quando não encontrada:**

HTTP 404 – Not Found.

### Atualizar tarefa

**Método:** PUT

**Endpoint:** `/api/tarefas/{id}`

**Entrada:**

```json
{
  "titulo": "Estudar C# atualizado",
  "descricao": "Revisar conceitos de C# e .NET 10",
  "concluida": false
}


Ou seja, deve ficar:

```markdown
```json
{
  "titulo": "Estudar C# atualizado",
  "descricao": "Revisar conceitos de C# e .NET 10",
  "concluida": false
}

```markdown
**Resposta esperada:**

HTTP 200 – OK.

Retorna os dados da tarefa atualizada.

### Concluir tarefa

**Método:** PUT

**Endpoint:** `/api/tarefas/{id}/concluir`

**Exemplo:** `/api/tarefas/1/concluir`

**Resposta esperada:**

HTTP 200 – OK.

Retorna a tarefa com o campo `concluida` alterado para `true`.

### Excluir tarefa

**Método:** DELETE

**Endpoint:** `/api/tarefas/{id}`

**Exemplo:** `/api/tarefas/1`

**Resposta esperada:**

HTTP 204 – No Content.

A tarefa é removida do banco de dados.

### Tratamento de tarefa inexistente

Para operações realizadas com um identificador que não corresponde a uma tarefa cadastrada, a API deve retornar:

HTTP 404 – Not Found.

## 11. Persistência de dados

A aplicação utiliza o Entity Framework Core para realizar a comunicação com o banco de dados SQLite.

O contexto da aplicação é representado pela classe `AppDbContext`, responsável pelo acesso à entidade `Tarefa`.

Arquivo:

```text
TaskManager.API/Data/AppDbContext.cs

O AppDbContext é responsável por disponibilizar o acesso à tabela de tarefas por meio do Entity Framework Core.

### Banco de dados

O banco de dados utilizado é o SQLite, escolhido por sua simplicidade e adequação ao escopo acadêmico do projeto.

Arquivo do banco:

```text
TaskManager.API/taskmanager.db

12. Arquitetura da aplicação

O projeto utiliza uma arquitetura simples, adequada ao escopo acadêmico, com separação entre modelo, persistência, controller e testes.

TaskManager/
│
├── TaskManager.API/
│   ├── Controllers/
│   │   └── TarefasController.cs
│   ├── Data/
│   │   └── AppDbContext.cs
│   ├── Migrations/
│   ├── Models/
│   │   └── Tarefa.cs
│   ├── Program.cs
│   └── TaskManager.API.csproj
│
├── TaskManager.Tests/
│   ├── TarefasControllerTests.cs
│   ├── TestDbContextFactory.cs
│   └── TaskManager.Tests.csproj
│
├── TaskManager.slnx
└── README.md

O fluxo básico da aplicação é:

Cliente
   ↓
TarefasController
   ↓
AppDbContext
   ↓
Entity Framework Core
   ↓
SQLite

O controller recebe as requisições HTTP, executa as operações necessárias por meio do contexto de dados e retorna a resposta correspondente.

13. Testes automatizados

Os testes automatizados foram desenvolvidos utilizando xUnit e estão localizados em:

TaskManager.Tests/TarefasControllerTests.cs

A classe TestDbContextFactory é utilizada para criar o contexto necessário para os testes:

TaskManager.Tests/TestDbContextFactory.cs

Foram implementados testes para as principais operações da aplicação:

Operação	Teste
Criar	Criar_DeveCriarTarefaComSucesso
Listar	Listar_DeveRetornarTodasAsTarefas
Buscar	BuscarPorId_DeveRetornarTarefaExistente
Buscar inexistente	BuscarPorId_DeveRetornar404QuandoNaoEncontrar
Atualizar	Atualizar_DeveAtualizarTarefaComSucesso
Atualizar inexistente	Atualizar_DeveRetornar404QuandoTarefaNaoExistir
Concluir	Concluir_DeveMarcarTarefaComoConcluida
Concluir inexistente	Concluir_DeveRetornar404QuandoTarefaNaoExistir
Excluir	Excluir_DeveExcluirTarefaComSucesso
Excluir inexistente	Excluir_DeveRetornar404QuandoTarefaNaoExistir

A última execução da suíte apresentou:

Total: 10
Falhou: 0
Bem-sucedido: 10
Ignorado: 0

Portanto, todos os testes implementados foram executados com sucesso.

14. Cobertura e execução

A cobertura de testes foi coletada utilizando o recurso XPlat Code Coverage:

dotnet test --collect:"XPlat Code Coverage"

O comando gerou o arquivo:

coverage.cobertura.xml

A partir desse arquivo foi gerado um relatório HTML utilizando o ReportGenerator.

A cobertura foi utilizada como evidência complementar da execução dos testes e para identificar quais partes do código foram exercitadas pela suíte automatizada.

Para executar o projeto:

dotnet restore
dotnet build
dotnet run --project .\TaskManager.API

Para executar os testes:

dotnet test
15. Versionamento, decisões e limitações

O projeto utiliza Git para controle de versão e GitHub para hospedagem do código.

Repositório:

https://github.com/vitornog1/TaskManager

A implementação foi realizada individualmente e adaptada ao contexto acadêmico da atividade.

As principais decisões técnicas foram:

Utilização de C# e .NET 10;
Utilização de ASP.NET Core para criação da API REST;
Utilização de Entity Framework Core;
Utilização de SQLite para persistência;
Utilização de xUnit para testes automatizados;
Utilização de Git e GitHub para versionamento.

O projeto possui escopo reduzido e não contempla autenticação, controle de permissões, interface web, aplicativo mobile, notificações ou integrações externas.

Essas limitações são intencionais e mantêm o projeto compatível com o objetivo da entrega acadêmica individual.