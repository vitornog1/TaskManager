# TaskManager

## 1. Sobre o projeto

O TaskManager é uma API para gerenciamento de tarefas, desenvolvida como projeto individual no Bootcamp 3.

O sistema permite criar, consultar, atualizar, concluir e excluir tarefas, utilizando uma API REST com persistência em banco de dados SQLite.

## 2. Objetivo

Desenvolver uma aplicação backend simples aplicando conceitos de:

- Desenvolvimento de APIs REST;
- Persistência de dados;
- Entity Framework Core;
- Testes automatizados;
- Controle de versão com Git e GitHub;
- Organização e documentação do desenvolvimento.

## 3. Tecnologias utilizadas

- C#
- .NET 10
- ASP.NET Core
- Entity Framework Core
- SQLite
- xUnit
- Git
- GitHub
- PowerShell
- ReportGenerator

## 4. Funcionalidades

A API possui as seguintes operações:

- Criar uma tarefa;
- Listar todas as tarefas;
- Buscar uma tarefa por ID;
- Atualizar uma tarefa;
- Marcar uma tarefa como concluída;
- Excluir uma tarefa.

## 5. Estrutura do projeto

```text
TaskManager/
│
├── TaskManager.API/
│   ├── Controllers/
│   │   └── TarefasController.cs
│   │
│   ├── Data/
│   │   └── AppDbContext.cs
│   │
│   ├── Migrations/
│   │
│   ├── Models/
│   │   └── Tarefa.cs
│   │
│   ├── Program.cs
│   └── TaskManager.API.csproj
│
├── TaskManager.Tests/
│   ├── TarefasControllerTests.cs
│   ├── TestDbContextFactory.cs
│   └── TaskManager.Tests.csproj
│
├── TaskManager.slnx
└── .gitignore