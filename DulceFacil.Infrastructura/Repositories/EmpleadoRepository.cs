using DulceFacil.Dominio.Entities;
using DulceFacil.Dominio.Repositories;
using DulceFacil.Infrastructura.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DulceFacil.Infrastructura.Repositories
{
    public class EmpleadoRepository : IEmpleadoRepository
    {
        private readonly DulceFacilDBContext _context;

        public EmpleadoRepository(DulceFacilDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Empleados>> GetAllAsync()
        {
            return await _context.Empleados.ToListAsync();
        }

        public async Task<Empleados?> GetByIdAsync(Guid id)
        {
            return await _context.Empleados.FindAsync(id);
        }

        public async Task AddAsync(Empleados empleado)
        {
            await _context.Empleados.AddAsync(empleado);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(Empleados empleado)
        {
            if (!_context.Empleados.Any(e => e.Id == empleado.Id)) return false;

            _context.Empleados.Update(empleado);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado == null) return false;

            _context.Empleados.Remove(empleado);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
