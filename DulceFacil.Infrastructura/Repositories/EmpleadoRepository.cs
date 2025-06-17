using DulceFacil.Dominio.Entities;
using DulceFacil.Infrastructura.Persistence;
using Microsoft.EntityFrameworkCore;

public class EmpleadoRepository
{
    private readonly DulceFacilDBContext _context;

    public EmpleadoRepository(DulceFacilDBContext context)
    {
        _context = context;
    }

    public async Task<List<Empleados>> GetAllAsync() => await _context.Empleados.ToListAsync();

    public async Task<Empleados?> GetByIdAsync(Guid id) => await _context.Empleados.FindAsync(id);

    public async Task<Empleados> AddAsync(Empleados empleado)
    {
        empleado.Id = Guid.NewGuid();
        _context.Empleados.Add(empleado);
        await _context.SaveChangesAsync();
        return empleado;
    }

    public async Task<bool> UpdateAsync(Empleados empleado)
    {
        var exists = await _context.Empleados.AnyAsync(e => e.Id == empleado.Id);
        if (!exists) return false;

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
