using DulceFacil.Dominio.Entities;
using DulceFacil.Dominio.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DulceFacil.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidosController : ControllerBase
    {
        private readonly IPedidoRepository _repository;

        public PedidosController(IPedidoRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var pedidos = await _repository.GetAllAsync();
            return Ok(pedidos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var pedido = await _repository.GetByIdAsync(id);
            if (pedido == null) return NotFound();
            return Ok(pedido);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Pedidos pedido)
        {
            if (pedido.Id == Guid.Empty)
                pedido.Id = Guid.NewGuid();

            await _repository.AddAsync(pedido);
            return CreatedAtAction(nameof(GetById), new { id = pedido.Id }, pedido);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Pedidos pedido)
        {
            if (id != pedido.Id) return BadRequest();
            var updated = await _repository.UpdateAsync(pedido);
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
