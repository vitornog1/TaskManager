# Relato de Experiência – TaskManager

## 1. Contexto

O meu projeto TaskManager foi desenvolvido individualmente como adaptação da atividade proposta originalmente para desenvolvimento em equipe, devido ao não encontro de integrantes para formar a equipe

A adaptação foi realizada para manter o projeto dentro do escopo da atividade, concentrando em um único estudante as atividades de implementação, testes, documentação, versionamento e validação.

## 2. Desenvolvimento

Durante o desenvolvimento, foram aplicados conceitos de desenvolvimento de API REST, persistência de dados, testes automatizados, controle de versão e documentação técnica.

O projeto foi organizado utilizando branches específicas para as entregas, commits e Pull Requests, mantendo o histórico das alterações no GitHub.

## 3. Principais desafios

Um dos principais desafios ocorreu durante a execução da aplicação em Docker. Inicialmente, a API não conseguia consultar as tarefas porque a tabela `Tarefas` não existia no banco SQLite utilizado pelo container.

O problema foi solucionado com a aplicação automática das migrations do Entity Framework Core durante a inicialização da aplicação.

Também houve um problema durante o envio de uma requisição POST pelo PowerShell, relacionado ao formato de envio do JSON. O comando foi ajustado para enviar o conteúdo corretamente em UTF-8.

## 4. Testes e validação

A aplicação foi validada por meio de testes automatizados utilizando xUnit.

A suíte possui 10 testes, com 10 testes aprovados, sem falhas ou testes ignorados.

Além dos testes automatizados, a aplicação foi executada em ambiente Docker e seus endpoints foram validados por meio de requisições HTTP.

## 5. Uso de Inteligência Artificial

A Inteligência Artificial foi utilizada como ferramenta de apoio durante o desenvolvimento.

O ChatGPT auxiliou na organização do projeto, implementação e revisão de funcionalidades, criação e revisão de testes, identificação de problemas, configuração do Docker, utilização do Git e GitHub e elaboração da documentação.

As sugestões fornecidas pela IA foram analisadas e validadas por mim (Vítor Nogueira Lourenco) antes de serem incorporadas ao projeto.

## 6. Aprendizados

O desenvolvimento proporcionou aprendizado prático sobre construção de APIs REST, persistência com Entity Framework Core e SQLite, testes automatizados, Docker, Git, GitHub e documentação técnica.

Também foi possível compreender a importância de testar a aplicação em diferentes ambientes e de validar as sugestões produzidas por ferramentas de Inteligência Artificial.

## 7. Resultado

Ao final do desenvolvimento, o TaskManager possui uma API funcional para gerenciamento de tarefas, testes automatizados aprovados, ambiente Docker configurado e documentação técnica relacionada à solução e ao processo de desenvolvimento.