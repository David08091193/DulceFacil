using DulceFacil.Infrastructura.Persistence;
using Microsoft.EntityFrameworkCore;
using DulceFacil.Dominio.Entities;

public class ProductosRepository
{
    private readonly DulceFacilDBContext _context;

    public ProductosRepository(DulceFacilDBContext context)
    {
        _context = context;
    }

    public async Task<List<Productos>> GetAllAsync()
    {
        return await _context.Productos.ToListAsync();
    }

    public async Task<Productos?> GetByIdAsync(Guid id)
    {
        return await _context.Productos.FindAsync(id);
    }

    public async Task<Productos> AddAsync(Productos producto)
    {
        _context.Productos.Add(producto);
        await _context.SaveChangesAsync();
        return producto;
    }

    public async Task<bool> UpdateAsync(Productos producto)
    {
        var exist = await _context.Productos.AnyAsync(p => p.Id == producto.Id);
        if (!exist) return false;

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
