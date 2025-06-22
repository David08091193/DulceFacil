using DulceFacil.Dominio.Entities;
using DulceFacil.Dominio.Repositories;
using DulceFacil.Infrastructura.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DulceFacil.Infrastructura.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DulceFacilDBContext _context;

        public UsuarioRepository(DulceFacilDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Usuarios>> GetAllAsync()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<Usuarios?> GetByIdAsync(Guid id)
        {
            return await _context.Usuarios.FindAsync(id);
        }

        public async Task AddAsync(Usuarios usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(Usuarios usuario)
        {
            if (!_context.Usuarios.Any(u => u.Id == usuario.Id)) return false;

            _context.Usuarios.Update(usuario);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null) return false;

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
