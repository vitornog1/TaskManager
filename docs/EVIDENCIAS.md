# Evidências de Execução – TaskManager

## 1. Execução dos testes automatizados

Os testes automatizados foram executados utilizando o comando:

```powershell
dotnet test --logger "console;verbosity=normal"

Resultado obtido:

Total de testes: 10
Testes aprovados: 10
Testes com falha: 0
Testes ignorados: 0
Execução: bem-sucedida

Os testes abrangem as principais operações da API, incluindo criação, listagem, consulta, atualização, conclusão e exclusão de tarefas, além do tratamento de tarefas inexistentes.

2. Cobertura de testes

A cobertura de testes foi gerada utilizando o coletor de cobertura do .NET:

dotnet test --collect:"XPlat Code Coverage"

O arquivo de cobertura gerado foi:

TaskManager.Tests/TestResults/<identificador>/coverage.cobertura.xml

O relatório HTML foi gerado utilizando o ReportGenerator e disponibilizado no diretório:

coverage-report/
3. Execução da aplicação com Docker

A imagem da API foi construída utilizando:

docker build -t taskmanager-api .

A construção da imagem foi concluída com sucesso.

A aplicação foi executada em container Docker utilizando a porta 8080.

A execução foi validada por meio da requisição:

Invoke-RestMethod http://localhost:8080/api/tarefas

A aplicação apresentou funcionamento em ambiente containerizado após a configuração da persistência do banco SQLite.

4. Ambiente utilizado
Linguagem: C#
Framework: .NET 10
Banco de dados: SQLite
ORM: Entity Framework Core
Testes: xUnit
Containerização: Docker
Versionamento: Git
Repositório: GitHub
5. Observações

O projeto possui finalidade acadêmica e foi desenvolvido individualmente.

As evidências apresentadas neste documento têm como objetivo demonstrar o funcionamento da aplicação, a execução dos testes automatizados, a geração da cobertura e a utilização do ambiente containerizado.

Durante a execução dos comandos, foram apresentados avisos relacionados à vulnerabilidade conhecida do pacote Microsoft.OpenApi 2.0.0. Esses avisos não impediram a compilação, execução ou aprovação dos testes.