using DulceFacil.Dominio.Entities;
using DulceFacil.Dominio.Repositories;
using DulceFacil.Infrastructura.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DulceFacil.Infrastructura.Repositories
{
    public class DetallePedidoRepository : IDetallePedidoRepository
    {
        private readonly DulceFacilDBContext _context;

        public DetallePedidoRepository(DulceFacilDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DetallePedidos>> GetAllAsync()
        {
            return await _context.DetallePedidos.ToListAsync();
        }

        public async Task<DetallePedidos?> GetByIdAsync(Guid id)
        {
            return await _context.DetallePedidos.FindAsync(id);
        }

        public async Task AddAsync(DetallePedidos detalle)
        {
            await _context.DetallePedidos.AddAsync(detalle);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(DetallePedidos detalle)
        {
            if (!_context.DetallePedidos.Any(d => d.Id == detalle.Id)) return false;

            _context.DetallePedidos.Update(detalle);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var detalle = await _context.DetallePedidos.FindAsync(id);
            if (detalle == null) return false;

            _context.DetallePedidos.Remove(detalle);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
