using Microsoft.AspNetCore.Mvc;
using DulceFacil.Dominio.Entities;




[ApiController]
[Route("api/[controller]")]
public class ClientesController : ControllerBase
{
    private readonly ClienteRepository _repository;

    public ClientesController(ClienteRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var clientes = await _repository.GetAllAsync();
        return Ok(clientes);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var cliente = await _repository.GetByIdAsync(id);
        if (cliente is null) return NotFound(); // Fixed CS0019 by using 'is' for null check
        return Ok(cliente);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Clientes cliente)
    {
        var created = await _repository.AddAsync(cliente);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, Clientes cliente)
    {
        if (id != cliente.Id) return BadRequest();

        var updated = await _repository.UpdateAsync(cliente);
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
