@'
# Erros e Reespecificação – TaskManager

## 1. Objetivo

Este documento registra os problemas identificados durante o desenvolvimento e os ajustes realizados a partir da execução e validação da aplicação.

## 2. Problema identificado no ambiente Docker

Durante a execução da API em um container Docker, a aplicação apresentou erro ao consultar as tarefas porque a tabela `Tarefas` ainda não existia no banco SQLite utilizado pelo container.

### Causa

O banco de dados utilizado pelo container não possuía a estrutura criada pela migration inicial.

### Correção

Foi configurada a aplicação para aplicar automaticamente as migrations do Entity Framework Core durante a inicialização.

Após a correção, a migration `InitialCreate` foi aplicada e a tabela `Tarefas` passou a ser criada corretamente.

### Validação

A aplicação foi executada novamente no Docker e a consulta:

```powershell
Invoke-RestMethod http://localhost:8080/api/tarefas