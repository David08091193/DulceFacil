using DulceFacil.Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using DulceFacil.Infrastructura.Persistence;


public class ClienteRepository
{
    private readonly DulceFacilDBContext _context;

    public ClienteRepository(DulceFacilDBContext context)
    {
        _context = context;
    }

    public async Task<List<Clientes>> GetAllAsync()
    {
        return await _context.Clientes.ToListAsync();
    }

    public async Task<Clientes?> GetByIdAsync(Guid id)
    {
        return await _context.Clientes.FindAsync(id);
    }

    public async Task<Clientes> AddAsync(Clientes cliente)
    {
        cliente.Id = Guid.NewGuid(); // Genera el ID automáticamente
        _context.Clientes.Add(cliente);
        await _context.SaveChangesAsync();
        return cliente;
    }

    public async Task<bool> UpdateAsync(Clientes cliente)
    {
        var exists = await _context.Clientes.AnyAsync(c => c.Id == cliente.Id);
        if (!exists) return false;

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
