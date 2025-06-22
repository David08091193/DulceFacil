using DulceFacil.Dominio.Entities;
using DulceFacil.Dominio.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DulceFacil.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpleadosController : ControllerBase
    {
        private readonly IEmpleadoRepository _repository;

        public EmpleadosController(IEmpleadoRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var empleados = await _repository.GetAllAsync();
            return Ok(empleados);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var empleado = await _repository.GetByIdAsync(id);
            if (empleado == null) return NotFound();
            return Ok(empleado);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Empleados empleado)
        {
            if (empleado.Id == Guid.Empty)
                empleado.Id = Guid.NewGuid();

            await _repository.AddAsync(empleado);
            return CreatedAtAction(nameof(GetById), new { id = empleado.Id }, empleado);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Empleados empleado)
        {
            if (id != empleado.Id) return BadRequest();
            var updated = await _repository.UpdateAsync(empleado);
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
