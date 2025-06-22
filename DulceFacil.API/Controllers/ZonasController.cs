using DulceFacil.Dominio.Entities;
using DulceFacil.Dominio.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DulceFacil.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ZonasController : ControllerBase
    {
        private readonly IZonaRepository _repository;

        public ZonasController(IZonaRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var zonas = await _repository.GetAllAsync();
            return Ok(zonas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var zona = await _repository.GetByIdAsync(id);
            if (zona == null) return NotFound();
            return Ok(zona);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Zonas zona)
        {
            if (zona.Id == Guid.Empty)
                zona.Id = Guid.NewGuid();

            await _repository.AddAsync(zona);
            return CreatedAtAction(nameof(GetById), new { id = zona.Id }, zona);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Zonas zona)
        {
            if (id != zona.Id) return BadRequest();
            var updated = await _repository.UpdateAsync(zona);
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
}
