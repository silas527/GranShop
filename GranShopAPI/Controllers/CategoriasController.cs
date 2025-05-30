using GranShopAPI.Data;
using GranShopAPI.Models;
using Microsoft.AspNwetCore.Mvc;

namespace GranShopAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategorisController(AppDbContext db) : ControllerBase
{
    private readonly AppDbContext _db = db;

    [HttpGet]
    public IActionResult Get()
    {
        return OK(_db.Categorias.Tolist());
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var categoria = _db.Categorias.Find(id);
        if (categoria == null)
            return Notfund();
        return Ok (categoria);
    }
    [HttpPost]
    public IActionResult Create([FromBody] Categoria categoria)
    {
        if (!ModelState.IsValid)
            return BadRequest("Categoria informada com problemas");
        _db.Categorias.Add(categoria);
        _db.SaveChanges();
        return CreatedAtAction(nameof(GET), categoria.Id, new { categoria});
    }
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var catergoria = _db.Categoria.Find(id);
        if (categoria == null)
            return Notfund();
        _db.Categoria.Remove(categoria);
        _db.SaveChangens();
        return NoContent();
    }
}