# ADR-002 — Utilização de SQLite com Entity Framework Core

## Status

Aceita

## Contexto

O TaskManager precisa armazenar as tarefas de forma persistente, mantendo os dados disponíveis após a execução da aplicação.

## Decisão

Foi adotado o SQLite como banco de dados e o Entity Framework Core como ORM para realizar o acesso e a persistência dos dados.

## Justificativa

O SQLite é simples de configurar e adequado ao escopo do projeto acadêmico. O Entity Framework Core facilita o mapeamento das entidades e o gerenciamento das operações no banco de dados.

## Trade-off

A escolha do SQLite reduz a complexidade de configuração do banco de dados, porém possui recursos mais limitados quando comparado a sistemas gerenciadores de banco de dados mais robustos.

## Consequência

As tarefas são persistidas no banco SQLite e a aplicação utiliza o Entity Framework Core para realizar as operações de consulta, inclusão, atualização e exclusão dos registros.