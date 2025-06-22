using DulceFacil.Dominio.Entities;
using DulceFacil.Dominio.Repositories;
using DulceFacil.Infrastructura.Persistence;
using Microsoft.EntityFrameworkCore;


namespace DulceFacil.Infrastructura.Repositories
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly DulceFacilDBContext _context;

        public ProductoRepository(DulceFacilDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Productos>> GetAllAsync()
        {
            return await _context.Productos.ToListAsync();
        }

        public async Task<Productos?> GetByIdAsync(Guid id)
        {
            return await _context.Productos.FindAsync(id);
        }

        public async Task AddAsync(Productos producto)
        {
            await _context.Productos.AddAsync(producto);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(Productos producto)
        {
            if (!_context.Productos.Any(p => p.Id == producto.Id)) return false;

            _context.Productos.Update(producto);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null) return false;

            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
