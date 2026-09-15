# ADR-003 — Utilização de Docker

## Status

Aceita

## Contexto

O projeto precisa possuir um ambiente de execução padronizado, permitindo que a aplicação seja executada de forma consistente independentemente do ambiente utilizado.

## Decisão

Foi adotado o Docker para disponibilizar a aplicação em um ambiente containerizado.

O projeto possui um Dockerfile e um arquivo docker-compose.yml para auxiliar na configuração e execução.

## Justificativa

O Docker permite padronizar o ambiente de execução da API e facilita sua implantação e demonstração.

## Trade-off

A utilização de containers adiciona uma etapa de configuração em relação à execução direta da aplicação, mas proporciona maior padronização do ambiente.

## Consequência

A API pode ser executada em um container Docker, com a aplicação realizando a aplicação das migrations do Entity Framework Core durante a inicialização.