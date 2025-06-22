using DulceFacil.Dominio.Entities;
using DulceFacil.Dominio.Repositories;
using DulceFacil.Infrastructura.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DulceFacil.Infrastructura.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly DulceFacilDBContext _context;

        public PedidoRepository(DulceFacilDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Pedidos>> GetAllAsync()
        {
            return await _context.Pedidos.ToListAsync();
        }

        public async Task<Pedidos?> GetByIdAsync(Guid id)
        {
            return await _context.Pedidos.FindAsync(id);
        }

        public async Task AddAsync(Pedidos pedido)
        {
            await _context.Pedidos.AddAsync(pedido);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(Pedidos pedido)
        {
            if (!_context.Pedidos.Any(p => p.Id == pedido.Id)) return false;

            _context.Pedidos.Update(pedido);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var pedido = await _context.Pedidos.FindAsync(id);
            if (pedido == null) return false;

            _context.Pedidos.Remove(pedido);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
