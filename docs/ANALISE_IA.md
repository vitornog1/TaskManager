# Análise Comparativa e Avaliação Crítica de Ferramentas de IA

## 1. Ferramenta de IA utilizada no projeto

A ferramenta de Inteligência Artificial efetivamente utilizada como apoio durante o desenvolvimento do TaskManager foi o **ChatGPT**. IMPORTANTE LEMBRAR QUE O USO DE IA FOI SOMENTE PARA AUXILIAR O PROJETO, TODOS OS PROCESSOS DO PROJETO FORAM AVALIADOS E TESTADOS/AUTOMATIZADOS, etc.

O ChatGPT foi utilizado principalmente para:
- Auxiliar na implementação da API;
- Apoiar a criação e revisão dos testes automatizados;
- Auxiliar na identificação e correção de problemas;
- Orientar a configuração do Docker;
- Apoiar comandos e organização do Git e GitHub;
- Auxiliar na elaboração da documentação técnica.

As sugestões fornecidas pelo ChatGPT foram analisadas por mim (Vítor Nogueira Lourenco) antes de serem aplicadas. As alterações foram posteriormente validadas por meio da execução da aplicação, testes automatizados e verificações no ambiente do projeto.

## 2. Comparação entre ferramentas de IA

A atividade solicita a análise de ferramentas utilizadas ou avaliadas no desenvolvimento de software. Para este projeto, o ChatGPT foi a ferramenta efetivamente utilizada. As demais ferramentas foram consideradas apenas para fins de comparação e **não foram utilizadas diretamente no desenvolvimento do TaskManager**.

| Ferramenta | Principais características | Pontos fortes | Limitações |
|---|---|---|---|
| ChatGPT | Assistente de IA para programação, documentação, análise e resolução de problemas | Facilidade de interação, explicações detalhadas e auxílio em diferentes etapas do desenvolvimento | As respostas precisam ser analisadas e validadas pelo desenvolvedor |
| Claude Code | Ferramenta de IA voltada ao desenvolvimento diretamente no terminal | Pode auxiliar na análise e alteração de arquivos e na execução de tarefas de desenvolvimento | Exige maior familiaridade com ambiente de terminal |
| Codex CLI | Ferramenta de IA para auxílio no desenvolvimento por linha de comando | Integração com fluxo de desenvolvimento no terminal e automação de tarefas de programação | Depende de configuração e familiaridade com ferramentas de linha de comando |
| Cursor | Editor de código com recursos de Inteligência Artificial integrados | Integração direta com o código e facilidade para trabalhar com múltiplos arquivos | Pode exigir adaptação ao ambiente do editor |
| Antigravity | Ambiente voltado ao desenvolvimento com agentes de IA | Proposta de automação de tarefas de desenvolvimento utilizando agentes | Não foi utilizado neste projeto, portanto não houve validação prática de seus recursos |

## 3. Impacto real da IA no projeto

O impacto real da Inteligência Artificial no desenvolvimento do TaskManager ocorreu por meio da utilização do **ChatGPT**.

A ferramenta contribuiu principalmente para acelerar a resolução de problemas, orientar a implementação de funcionalidades, auxiliar nos testes e organizar a documentação. Ademais, a utilização da IA foi necessária devido ao projeto ter sido desenvolvido INDIVIDUALMENTE.

Entre os problemas em que houve apoio da IA estão:
- Problema relacionado à ausência da tabela `Tarefas` no banco SQLite utilizado pelo container Docker;
- Ajuste da aplicação para aplicar as migrations do Entity Framework Core durante a inicialização;
- Problema no envio de uma requisição JSON pelo PowerShell;
- Orientações relacionadas aos testes automatizados;
- Organização do versionamento e da documentação do projeto.

As demais ferramentas apresentadas na comparação não tiveram impacto direto no código ou na qualidade final do TaskManager, pois não foram utilizadas durante sua implementação.

## 4. Riscos e limitações do uso de IA

O uso de Inteligência Artificial durante o desenvolvimento apresenta alguns riscos que precisam ser considerados.

### 4.1 Alucinações e código incorreto

A IA pode apresentar respostas incorretas, código incompatível com o projeto ou soluções que não atendam exatamente aos requisitos.

Por esse motivo, nenhuma sugestão foi considerada automaticamente correta. As alterações foram analisadas e testadas antes de serem incorporadas ao projeto.

### 4.2 Código inseguro ou destrutivo

Sugestões de comandos ou alterações de código podem causar problemas no ambiente de desenvolvimento quando utilizadas sem análise.

Por isso, comandos e alterações foram executados de forma controlada e seus resultados foram verificados antes da continuidade do desenvolvimento.

### 4.3 Privacidade e vazamento de informações

Informações sensíveis, como senhas, tokens, credenciais ou dados pessoais, não devem ser compartilhadas com ferramentas de IA.

Durante o desenvolvimento do TaskManager, as orientações foram realizadas considerando o contexto técnico necessário para o projeto, sem utilizar informações confidenciais.

### 4.4 Propriedade intelectual e direitos autorais

Código ou conteúdo sugerido por ferramentas de IA deve ser analisado antes de ser utilizado, considerando possíveis questões relacionadas a propriedade intelectual e direitos autorais.

A utilização da IA neste projeto teve caráter de apoio ao desenvolvimento, com análise e adaptação das sugestões pelo estudante.

## 5. Revisão humana e homologação

A revisão humana foi considerada obrigatória durante o desenvolvimento.

As sugestões do ChatGPT foram analisadas pelo estudante e posteriormente verificadas por meio de:
- Execução da aplicação;
- Testes automatizados;
- Validação das requisições da API;
- Verificação do funcionamento em Docker;
- Análise dos arquivos modificados.

Dessa forma, a IA foi utilizada como ferramenta de apoio, enquanto as decisões técnicas, implementação final e homologação permaneceram sob responsabilidade do estudante.

## 6. Conclusão

O uso do ChatGPT contribuiu para o desenvolvimento do TaskManager, principalmente na resolução de problemas, implementação, testes, documentação e organização do projeto.

As outras ferramentas analisadas apresentam diferentes propostas para apoiar o desenvolvimento de software, porém não foram utilizadas diretamente neste projeto.

A experiência demonstrou que a Inteligência Artificial pode aumentar a produtividade do desenvolvimento, mas suas sugestões precisam passar por análise, revisão e validação humana antes de serem incorporadas ao sistema.