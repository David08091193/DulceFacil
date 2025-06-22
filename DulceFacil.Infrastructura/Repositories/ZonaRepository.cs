using DulceFacil.Dominio.Entities;
using DulceFacil.Dominio.Repositories;
using DulceFacil.Infrastructura.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DulceFacil.Infrastructura.Repositories
{
    public class ZonaRepository : IZonaRepository
    {
        private readonly DulceFacilDBContext _context;

        public ZonaRepository(DulceFacilDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Zonas>> GetAllAsync()
        {
            return await _context.Zonas.ToListAsync();
        }

        public async Task<Zonas?> GetByIdAsync(Guid id)
        {
            return await _context.Zonas.FindAsync(id);
        }

        public async Task AddAsync(Zonas zona)
        {
            await _context.Zonas.AddAsync(zona);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(Zonas zona)
        {
            if (!_context.Zonas.Any(z => z.Id == zona.Id)) return false;

            _context.Zonas.Update(zona);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var zona = await _context.Zonas.FindAsync(id);
            if (zona == null) return false;

            _context.Zonas.Remove(zona);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
