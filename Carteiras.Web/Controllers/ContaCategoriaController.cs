using Conta.Core.Aggregates.ContaCategoria;
using Conta.Data.Repositories;
using Shared.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Carteiras.Web.Controllers;

public class ContaCategoriaController : Controller
{
    private readonly ContaCategoriaRepository _repository;

    public ContaCategoriaController(ContaCategoriaRepository repository)
    {
        _repository = repository;
    }

    public async Task<IActionResult> Index()
    {
        var categorias = await _repository.ListarAsync();
        return View(categorias);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(string nome)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                ModelState.AddModelError("", "O nome é obrigatório.");
                return View();
            }

            var categoria = new ContaCategoria(nome);
            await _repository.AdicionarAsync(categoria);
            await _repository.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        catch (Shared.Core.Domain.Exceptions.DomainException ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View();
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", $"Erro ao criar categoria: {ex.Message}");
            return View();
        }
    }

    [HttpGet]
    public async Task<IActionResult> Details(Guid id)
    {
        var categoria = await _repository.BuscarPorIdAsync(id);
        
        if (categoria == null)
        {
            return NotFound();
        }

        return View(categoria);
    }
}
