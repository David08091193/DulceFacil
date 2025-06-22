using DulceFacil.Dominio.Entities;

namespace DulceFacil.Dominio.Repositories
{
    public interface IProductoRepository
    {
        Task<IEnumerable<Productos>> GetAllAsync();
        Task<Productos?> GetByIdAsync(Guid id);
        Task AddAsync(Productos producto);
        Task<bool> UpdateAsync(Productos producto);
        Task<bool> DeleteAsync(Guid id);
    }
}
