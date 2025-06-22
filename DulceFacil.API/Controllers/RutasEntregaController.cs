using DulceFacil.Dominio.Entities;
using DulceFacil.Dominio.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DulceFacil.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RutasEntregaController : ControllerBase
    {
        private readonly IRutaEntregaRepository _repository;

        public RutasEntregaController(IRutaEntregaRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var rutas = await _repository.GetAllAsync();
            return Ok(rutas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var ruta = await _repository.GetByIdAsync(id);
            if (ruta == null) return NotFound();
            return Ok(ruta);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RutasEntrega ruta)
        {
            if (ruta.Id == Guid.Empty)
                ruta.Id = Guid.NewGuid();

            await _repository.AddAsync(ruta);
            return CreatedAtAction(nameof(GetById), new { id = ruta.Id }, ruta);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] RutasEntrega ruta)
        {
            if (id != ruta.Id) return BadRequest();
            var updated = await _repository.UpdateAsync(ruta);
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
