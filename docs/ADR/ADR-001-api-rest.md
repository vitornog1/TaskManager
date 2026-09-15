# ADR-001 — Utilização de API REST

## Status

Aceita

## Contexto

O TaskManager precisa disponibilizar as funcionalidades de gerenciamento de tarefas por meio de uma interface que permita comunicação entre clientes e o sistema.

## Decisão

Foi adotada uma API REST desenvolvida com ASP.NET Core para disponibilizar as operações de gerenciamento de tarefas.

Os recursos são acessados por meio de endpoints HTTP, utilizando métodos como GET, POST, PUT, PATCH e DELETE.

## Justificativa

A utilização de uma API REST permite organizar as funcionalidades do sistema de forma simples e padronizada, além de facilitar testes e integração com diferentes clientes.

## Trade-off

A solução exige que as operações sejam realizadas por meio de requisições HTTP, mas mantém a aplicação simples e adequada ao escopo do projeto acadêmico.

## Consequência

A aplicação possui endpoints HTTP definidos para criação, consulta, atualização, conclusão e exclusão de tarefas.