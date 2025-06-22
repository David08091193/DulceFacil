using DulceFacil.Dominio.Entities;
using DulceFacil.Dominio.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DulceFacil.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DetallePedidosController : ControllerBase
    {
        private readonly IDetallePedidoRepository _repository;

        public DetallePedidosController(IDetallePedidoRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var detalles = await _repository.GetAllAsync();
            return Ok(detalles);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var detalle = await _repository.GetByIdAsync(id);
            if (detalle == null) return NotFound();
            return Ok(detalle);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DetallePedidos detalle)
        {
            if (detalle.Id == Guid.Empty)
                detalle.Id = Guid.NewGuid();

            await _repository.AddAsync(detalle);
            return CreatedAtAction(nameof(GetById), new { id = detalle.Id }, detalle);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] DetallePedidos detalle)
        {
            if (id != detalle.Id) return BadRequest();
            var updated = await _repository.UpdateAsync(detalle);
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
