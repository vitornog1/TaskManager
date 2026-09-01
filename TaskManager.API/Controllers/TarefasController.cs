using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManager.API.Data;
using TaskManager.API.Models;

namespace TaskManager.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TarefasController : ControllerBase
{
    private readonly AppDbContext _context;

    public TarefasController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/tarefas
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Tarefa>>> Listar()
    {
        var tarefas = await _context.Tarefas
            .OrderBy(t => t.Id)
            .ToListAsync();

        return Ok(tarefas);
    }

    // GET: api/tarefas/1
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Tarefa>> BuscarPorId(int id)
    {
        var tarefa = await _context.Tarefas.FindAsync(id);

        if (tarefa is null)
        {
            return NotFound(new { mensagem = "Tarefa não encontrada." });
        }

        return Ok(tarefa);
    }

    // POST: api/tarefas
    [HttpPost]
    public async Task<ActionResult<Tarefa>> Criar(Tarefa tarefa)
    {
        if (string.IsNullOrWhiteSpace(tarefa.Titulo))
        {
            return BadRequest(new { mensagem = "O título é obrigatório." });
        }

        tarefa.Id = 0;
        tarefa.Concluida = false;
        tarefa.DataCriacao = DateTime.UtcNow;

        _context.Tarefas.Add(tarefa);
        await _context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(BuscarPorId),
            new { id = tarefa.Id },
            tarefa);
    }

    // PUT: api/tarefas/1
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Atualizar(int id, Tarefa dados)
    {
        var tarefa = await _context.Tarefas.FindAsync(id);

        if (tarefa is null)
        {
            return NotFound(new { mensagem = "Tarefa não encontrada." });
        }

        if (string.IsNullOrWhiteSpace(dados.Titulo))
        {
            return BadRequest(new { mensagem = "O título é obrigatório." });
        }

        tarefa.Titulo = dados.Titulo;
        tarefa.Descricao = dados.Descricao;

        await _context.SaveChangesAsync();

        return Ok(tarefa);
    }

    // PATCH: api/tarefas/1/concluir
    [HttpPatch("{id:int}/concluir")]
    public async Task<IActionResult> Concluir(int id)
    {
        var tarefa = await _context.Tarefas.FindAsync(id);

        if (tarefa is null)
        {
            return NotFound(new { mensagem = "Tarefa não encontrada." });
        }

        tarefa.Concluida = true;

        await _context.SaveChangesAsync();

        return Ok(tarefa);
    }

    // DELETE: api/tarefas/1
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Excluir(int id)
    {
        var tarefa = await _context.Tarefas.FindAsync(id);

        if (tarefa is null)
        {
            return NotFound(new { mensagem = "Tarefa não encontrada." });
        }

        _context.Tarefas.Remove(tarefa);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}