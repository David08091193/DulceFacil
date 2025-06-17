using DulceFacil.Dominio.Entities;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ProductosController : ControllerBase
{
    private readonly ProductoRepository _repository;

    public ProductosController(ProductoRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var productos = await _repository.GetAllAsync();
        return Ok(productos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var producto = await _repository.GetByIdAsync(id);
        if (producto == null) return NotFound();
        return Ok(producto);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Productos producto)
    {
        if (producto.Id == Guid.Empty)
            producto.Id = Guid.NewGuid(); // Esto genera el ID automáticamente en C#

        var created = await _repository.AddAsync(producto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] Productos producto)
    {
        if (producto.Id != id) return BadRequest();

        var updated = await _repository.UpdateAsync(producto);
        if (!updated) return NotFound();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleted = await _repository.DeleteAsync(id);
        if (!deleted) return NotFound();

        return NoContent();
    }
}
