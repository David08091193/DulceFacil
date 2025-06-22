using DulceFacil.Dominio.Entities;
using DulceFacil.Dominio.Repositories;
using DulceFacil.Infrastructura.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DulceFacil.Infrastructura.Repositories
{
    public class RutaEntregaRepository : IRutaEntregaRepository
    {
        private readonly DulceFacilDBContext _context;

        public RutaEntregaRepository(DulceFacilDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RutasEntrega>> GetAllAsync()
        {
            return await _context.RutasEntrega.ToListAsync();
        }

        public async Task<RutasEntrega?> GetByIdAsync(Guid id)
        {
            return await _context.RutasEntrega.FindAsync(id);
        }

        public async Task AddAsync(RutasEntrega ruta)
        {
            await _context.RutasEntrega.AddAsync(ruta);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(RutasEntrega ruta)
        {
            if (!_context.RutasEntrega.Any(r => r.Id == ruta.Id)) return false;

            _context.RutasEntrega.Update(ruta);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var ruta = await _context.RutasEntrega.FindAsync(id);
            if (ruta == null) return false;

            _context.RutasEntrega.Remove(ruta);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
