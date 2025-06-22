using DulceFacil.Dominio.Entities;
using DulceFacil.Dominio.Repositories;
using DulceFacil.Infrastructura.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DulceFacil.Infrastructura.Repositories
{
    public class ClientesRepository : IClienteRepository
    {
        private readonly DulceFacilDBContext _context;

        public ClientesRepository(DulceFacilDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Clientes>> GetAllAsync()
        {
            return await _context.Clientes.ToListAsync();
        }

        public async Task<Clientes?> GetByIdAsync(Guid id)
        {
            return await _context.Clientes.FindAsync(id);
        }

        public async Task AddAsync(Clientes cliente)
        {
            await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(Clientes cliente)
        {
            if (!_context.Clientes.Any(c => c.Id == cliente.Id))
                return false;

            _context.Clientes.Update(cliente);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null) return false;

            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
