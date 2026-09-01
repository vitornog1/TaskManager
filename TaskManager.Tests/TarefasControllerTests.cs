using Microsoft.AspNetCore.Mvc;
using TaskManager.API.Controllers;
using TaskManager.API.Models;

namespace TaskManager.Tests;

public class TarefasControllerTests
{
    [Fact]
    public async Task Criar_DeveCriarTarefaComSucesso()
    {
        // Arrange
        using var context = TestDbContextFactory.Create();
        var controller = new TarefasController(context);

        var tarefa = new Tarefa
        {
            Titulo = "Tarefa de teste",
            Descricao = "Teste de criação"
        };

        // Act
        var resultado = await controller.Criar(tarefa);

        // Assert
        var createdResult = Assert.IsType<CreatedAtActionResult>(resultado.Result);
        var tarefaCriada = Assert.IsType<Tarefa>(createdResult.Value);

        Assert.Equal(1, tarefaCriada.Id);
        Assert.Equal("Tarefa de teste", tarefaCriada.Titulo);
        Assert.Equal("Teste de criação", tarefaCriada.Descricao);
        Assert.False(tarefaCriada.Concluida);
    }


    [Fact]
    public async Task Listar_DeveRetornarTodasAsTarefas()
    {
        // Arrange
        using var context = TestDbContextFactory.Create();

        context.Tarefas.AddRange(
            new Tarefa
            {
                Titulo = "Tarefa 1",
                Descricao = "Primeira tarefa"
            },
            new Tarefa
            {
                Titulo = "Tarefa 2",
                Descricao = "Segunda tarefa"
            }
        );

        await context.SaveChangesAsync();

        var controller = new TarefasController(context);

        // Act
        var resultado = await controller.Listar();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(resultado.Result);
        var tarefas = Assert.IsAssignableFrom<IEnumerable<Tarefa>>(okResult.Value);

        Assert.Equal(2, tarefas.Count());
    }


    [Fact]
    public async Task BuscarPorId_DeveRetornarTarefaExistente()
    {
        // Arrange
        using var context = TestDbContextFactory.Create();

        var tarefa = new Tarefa
        {
            Titulo = "Tarefa existente",
            Descricao = "Teste de busca"
        };

        context.Tarefas.Add(tarefa);
        await context.SaveChangesAsync();

        var controller = new TarefasController(context);

        // Act
        var resultado = await controller.BuscarPorId(tarefa.Id);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(resultado.Result);
        var tarefaRetornada = Assert.IsType<Tarefa>(okResult.Value);

        Assert.Equal(tarefa.Id, tarefaRetornada.Id);
        Assert.Equal("Tarefa existente", tarefaRetornada.Titulo);
    }


    [Fact]
    public async Task BuscarPorId_DeveRetornar404QuandoNaoEncontrar()
    {
        // Arrange
        using var context = TestDbContextFactory.Create();
        var controller = new TarefasController(context);

        // Act
        var resultado = await controller.BuscarPorId(999);

        // Assert
        var notFoundResult = Assert.IsType<NotFoundObjectResult>(resultado.Result);

        Assert.NotNull(notFoundResult.Value);
    }


    [Fact]
    public async Task Atualizar_DeveAtualizarTarefaComSucesso()
    {
        // Arrange
        using var context = TestDbContextFactory.Create();

        var tarefa = new Tarefa
        {
            Titulo = "Título antigo",
            Descricao = "Descrição antiga"
        };

        context.Tarefas.Add(tarefa);
        await context.SaveChangesAsync();

        var controller = new TarefasController(context);

        var tarefaAtualizada = new Tarefa
        {
            Id = tarefa.Id,
            Titulo = "Título atualizado",
            Descricao = "Descrição atualizada",
            Concluida = false,
            DataCriacao = tarefa.DataCriacao
        };

        // Act
        var resultado = await controller.Atualizar(
            tarefa.Id,
            tarefaAtualizada
        );

        // Assert
        Assert.IsType<OkObjectResult>(resultado);

        var tarefaNoBanco = await context.Tarefas.FindAsync(tarefa.Id);

        Assert.NotNull(tarefaNoBanco);
        Assert.Equal("Título atualizado", tarefaNoBanco.Titulo);
        Assert.Equal("Descrição atualizada", tarefaNoBanco.Descricao);
    }


    [Fact]
    public async Task Atualizar_DeveRetornar404QuandoTarefaNaoExistir()
    {
        // Arrange
        using var context = TestDbContextFactory.Create();
        var controller = new TarefasController(context);

        var tarefa = new Tarefa
        {
            Titulo = "Tarefa inexistente",
            Descricao = "Teste de erro"
        };

        // Act
        var resultado = await controller.Atualizar(999, tarefa);

        // Assert
        Assert.IsType<NotFoundObjectResult>(resultado);
    }


    [Fact]
    public async Task Concluir_DeveMarcarTarefaComoConcluida()
    {
        // Arrange
        using var context = TestDbContextFactory.Create();

        var tarefa = new Tarefa
        {
            Titulo = "Tarefa pendente",
            Descricao = "Tarefa para concluir",
            Concluida = false
        };

        context.Tarefas.Add(tarefa);
        await context.SaveChangesAsync();

        var controller = new TarefasController(context);

        // Act
        var resultado = await controller.Concluir(tarefa.Id);

        // Assert
        Assert.IsType<OkObjectResult>(resultado);

        var tarefaNoBanco = await context.Tarefas.FindAsync(tarefa.Id);

        Assert.NotNull(tarefaNoBanco);
        Assert.True(tarefaNoBanco.Concluida);
    }


    [Fact]
    public async Task Concluir_DeveRetornar404QuandoTarefaNaoExistir()
    {
        // Arrange
        using var context = TestDbContextFactory.Create();
        var controller = new TarefasController(context);

        // Act
        var resultado = await controller.Concluir(999);

        // Assert
        Assert.IsType<NotFoundObjectResult>(resultado);
    }


    [Fact]
    public async Task Excluir_DeveExcluirTarefaComSucesso()
    {
        // Arrange
        using var context = TestDbContextFactory.Create();

        var tarefa = new Tarefa
        {
            Titulo = "Tarefa para excluir",
            Descricao = "Teste de exclusão"
        };

        context.Tarefas.Add(tarefa);
        await context.SaveChangesAsync();

        var controller = new TarefasController(context);

        // Act
        var resultado = await controller.Excluir(tarefa.Id);

        // Assert
        Assert.IsType<NoContentResult>(resultado);

        var tarefaNoBanco = await context.Tarefas.FindAsync(tarefa.Id);

        Assert.Null(tarefaNoBanco);
    }


    [Fact]
    public async Task Excluir_DeveRetornar404QuandoTarefaNaoExistir()
    {
        // Arrange
        using var context = TestDbContextFactory.Create();
        var controller = new TarefasController(context);

        // Act
        var resultado = await controller.Excluir(999);

        // Assert
        Assert.IsType<NotFoundObjectResult>(resultado);
    }
}