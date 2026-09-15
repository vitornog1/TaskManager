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

6. Pré-requisitos

Para executar o projeto localmente, recomenda-se possuir:

.NET SDK 10;
Git;
Docker Desktop, caso seja utilizada a execução containerizada.
7. Executando o projeto localmente

A partir do diretório raiz do projeto:

dotnet restore

Depois, compile o projeto:

dotnet build

Execute a API:

dotnet run --project .\TaskManager.API

A aplicação será disponibilizada na porta configurada pelo ambiente de execução.

8. Executando os testes

A suíte de testes automatizados utiliza xUnit.

Para executar os testes:

dotnet test --logger "console;verbosity=normal"

A última execução registrada apresentou:

Total de testes: 10
Aprovados: 10
Falhas: 0
Ignorados: 0
Execução de Teste Bem-sucedida.

Os testes abrangem as principais operações da API, incluindo:

Criação de tarefa;
Listagem de tarefas;
Busca de tarefa por ID;
Atualização de tarefa;
Conclusão de tarefa;
Exclusão de tarefa;
Tratamento de tarefas inexistentes.
Testes implementados

Os testes da suíte são:

Criar_DeveCriarTarefaComSucesso
Listar_DeveRetornarTodasAsTarefas
BuscarPorId_DeveRetornarTarefaExistente
BuscarPorId_DeveRetornar404QuandoNaoEncontrar
Atualizar_DeveAtualizarTarefaComSucesso
Atualizar_DeveRetornar404QuandoTarefaNaoExistir
Concluir_DeveMarcarTarefaComoConcluida
Concluir_DeveRetornar404QuandoTarefaNaoExistir
Excluir_DeveExcluirTarefaComSucesso
Excluir_DeveRetornar404QuandoTarefaNaoExistir
9. Cobertura de testes

A cobertura de testes pode ser coletada utilizando o mecanismo de cobertura do .NET:

dotnet test --collect:"XPlat Code Coverage"

O arquivo de cobertura é gerado no diretório de resultados dos testes:

TaskManager.Tests/TestResults/<identificador>/coverage.cobertura.xml

Quando utilizado o ReportGenerator, o relatório HTML é disponibilizado no diretório:

coverage-report/

A cobertura é utilizada como evidência complementar da execução da suíte automatizada.

10. Execução com Docker

A aplicação possui configuração para execução em ambiente containerizado.

A imagem da API pode ser construída utilizando:

docker build -t taskmanager-api .

Para executar o container:

docker run --rm -p 8080:8080 --name taskmanager-api taskmanager-api

Caso a porta 8080 já esteja sendo utilizada por outro container, os containers em execução podem ser consultados com:

docker ps

Os logs da aplicação podem ser consultados utilizando:

docker logs taskmanager-api

O projeto também possui um arquivo docker-compose.yml para auxiliar na configuração do ambiente.

11. Validação da API

Com a aplicação em execução, os endpoints podem ser testados por meio de requisições HTTP.

Exemplo de consulta:

Invoke-RestMethod http://localhost:8080/api/tarefas

A API disponibiliza operações para criação, consulta, atualização, conclusão e exclusão de tarefas.

12. Principais endpoints
Método	Endpoint	Descrição
GET	/api/tarefas	Lista todas as tarefas
GET	/api/tarefas/{id}	Consulta uma tarefa por ID
POST	/api/tarefas	Cria uma nova tarefa
PUT	/api/tarefas/{id}	Atualiza uma tarefa
PATCH	/api/tarefas/{id}/concluir	Marca uma tarefa como concluída
DELETE	/api/tarefas/{id}	Exclui uma tarefa

## 13. Arquitetura e decisões técnicas

A aplicação foi estruturada utilizando ASP.NET Core Web API.

O Entity Framework Core é utilizado como ORM para comunicação com o banco de dados SQLite.

As principais decisões técnicas foram:

Utilização de uma API REST para disponibilização das funcionalidades;
Separação entre Controllers, Models e camada de acesso aos dados;
Utilização do Entity Framework Core para persistência;
Utilização do SQLite como banco de dados;
Utilização do xUnit para testes automatizados;
Utilização do Docker para padronização do ambiente de execução.

### Fluxo da aplicação

```text
Cliente
   │
   ▼
API REST
ASP.NET Core
   │
   ▼
TarefasController
   │
   ▼
Entity Framework Core
   │
   ▼
Banco SQLite
   │
   ▼
Dados das tarefas
```
A especificação técnica detalhada encontra-se no arquivo:

docs/SDD.md

14. Uso de Inteligência Artificial

A Inteligência Artificial foi utilizada como ferramenta de apoio durante o desenvolvimento do projeto.

O ChatGPT foi utilizado para auxiliar em atividades como:

Organização da estrutura do projeto;
Implementação e revisão de funcionalidades;
Criação e revisão de testes;
Identificação e correção de erros;
Configuração e execução do ambiente Docker;
Orientação sobre Git e GitHub;
Organização da documentação;
Apoio na preparação das evidências da entrega.

Entre os exemplos de utilização estão:

Orientação para configuração e execução da API em Docker;
Identificação do problema relacionado à porta 8080 já estar em uso;
Análise do erro do SQLite relacionado à ausência da tabela Tarefas no ambiente do container;
Orientação para execução e validação dos testes automatizados;
Apoio na organização da documentação técnica;
Orientação para utilização de branches, commits, push e Pull Request.

Todas as sugestões foram analisadas, implementadas ou adaptadas pelo estudante e posteriormente validadas por meio da execução dos comandos, análise dos resultados e verificação do comportamento do projeto.

O registro detalhado encontra-se em:

docs/AI_AGENTS.md
15. Evidências de execução

As evidências relacionadas aos testes automatizados, cobertura, execução da aplicação, Docker e validação do projeto estão documentadas em:

docs/EVIDENCIAS.md
16. Controle de versão e fluxo de desenvolvimento

O projeto utiliza Git e GitHub para controle de versão.

Por se tratar de um projeto individual, o fluxo de desenvolvimento foi adaptado para manter uma organização semelhante ao fluxo colaborativo solicitado na atividade.

A entrega foi desenvolvida em uma branch específica:

feature/entrega-2

O fluxo utilizado foi:

main
  │
  └── feature/entrega-2
              │
              ├── alterações
              ├── commit
              └── push
                    │
                    ▼
              Pull Request #2
                    │
                    ▼
              merge → main

Após a validação do Pull Request, a branch da entrega foi integrada à branch main.

17. Desenvolvimento individual

O TaskManager foi desenvolvido individualmente.

Dessa forma, os itens relacionados à divisão de tarefas entre integrantes foram adaptados para um fluxo individual de desenvolvimento.

As atividades de implementação, testes, documentação, versionamento e validação foram realizadas pelo estudante.

Mesmo em um contexto individual, foram utilizados:

Branch específica para desenvolvimento;
Commits;
Pull Request;
Validação das alterações;
Integração com a branch main;
Testes automatizados;
Documentação técnica;
Registro de evidências.

18. Documentação

A documentação complementar do projeto está disponível no diretório docs/:

SDD.md

Documento de Especificação Técnica do projeto, contendo a descrição do problema, requisitos, componentes, regras e demais informações técnicas.

docs/SDD.md
AI_AGENTS.md

Documento que registra a utilização de Inteligência Artificial durante o desenvolvimento, incluindo finalidade, contexto, exemplos de utilização e processo de validação das sugestões.

docs/AI_AGENTS.md
EVIDENCIAS.md

Documento que registra as evidências de execução dos testes, cobertura, aplicação e ambiente Docker.

docs/EVIDENCIAS.md
19. Status da entrega

A primeira entrega contempla:

API REST funcional;
Persistência com SQLite;
Operações de criação, consulta, atualização, conclusão e exclusão;
Tratamento de recursos inexistentes;
Testes automatizados com xUnit;
10 testes aprovados;
Cobertura de testes;
Ambiente Docker;
Dockerfile;
Docker Compose;
Especificação técnica (SDD);
Registro do uso de Inteligência Artificial;
Evidências de execução;
Versionamento com Git e GitHub;
Branch específica para a entrega;
Pull Request integrado à branch main.

20. Observações

O projeto possui finalidade acadêmica e foi desenvolvido individualmente.

O uso de Inteligência Artificial ocorreu como ferramenta de apoio, permanecendo com o estudante a responsabilidade pela implementação, análise das sugestões, decisões técnicas e validação final da aplicação.

Durante algumas execuções foram apresentados avisos relacionados à vulnerabilidade conhecida do pacote Microsoft.OpenApi versão 2.0.0. Esses avisos não impediram a compilação do projeto nem a execução e aprovação dos testes automatizados.

## 21. Entrega 2 — Refinamento e documentação

Na Entrega 2, o projeto passou por uma etapa de refinamento, validação e organização da documentação técnica.

### Refinamento e validação

Foram realizados testes e validações da aplicação, incluindo a execução da suíte de testes automatizados e a execução da API em ambiente Docker.

Durante a validação foram identificados e corrigidos problemas relacionados ao ambiente de execução e ao envio de requisições.

O problema relacionado ao banco SQLite no ambiente Docker foi corrigido com a aplicação automática das migrations do Entity Framework Core durante a inicialização da aplicação.

Também foi corrigido um problema no envio de uma requisição POST pelo PowerShell, passando a utilizar a conversão do conteúdo para JSON e o envio em UTF-8.

Os problemas identificados e as respectivas correções estão registrados em:

docs/ERROS_E_REESPECIFICACAO.md

### Decisões arquiteturais

Foram registrados os principais motivos e trade-offs das escolhas técnicas utilizadas no projeto por meio de ADRs:

docs/ADR/ADR-001-api-rest.md

docs/ADR/ADR-002-sqlite-ef-core.md

docs/ADR/ADR-003-docker.md

### Relato de experiência

Foi elaborado um relato de experiência sobre o desenvolvimento individual do projeto, abordando os principais aprendizados, desafios e soluções encontradas durante o desenvolvimento.

O documento está disponível em:

docs/RELATO_DE_EXPERIENCIA.md

### Análise do uso de Inteligência Artificial

Foi elaborada uma análise comparativa das ferramentas de Inteligência Artificial relacionadas ao desenvolvimento de software.

A ferramenta efetivamente utilizada como apoio no desenvolvimento do TaskManager foi o ChatGPT. Claude Code, Codex CLI, Cursor e Antigravity foram apresentados apenas para comparação, não tendo sido utilizados diretamente na implementação do projeto.

A análise também aborda os riscos de alucinação, geração de código inseguro ou destrutivo, privacidade, confidencialidade, propriedade intelectual e a necessidade de revisão e homologação humana.

O documento está disponível em:

docs/ANALISE_IA.md

### Governança e versionamento

A Entrega 2 foi desenvolvida utilizando uma branch específica:

feature/entrega-2

Após as alterações e validações, foi realizado o Pull Request #2 para a branch main.

O Pull Request foi aprovado e integrado à branch main, mantendo o histórico das alterações registrado no GitHub.

### Resultado da Entrega 2

Ao final da Entrega 2, o projeto possui:

- Testes automatizados aprovados;
- Correções dos problemas identificados durante a validação;
- Processo de reespecificação documentado;
- ADRs registrados;
- Relato de experiência;
- Análise crítica do uso de Inteligência Artificial;
- Alterações organizadas em branch específica;
- Pull Request registrado no GitHub;
- Integração da Entrega 2 à branch main.