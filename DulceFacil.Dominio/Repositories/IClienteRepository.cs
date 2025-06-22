using DulceFacil.Dominio.Entities;

namespace DulceFacil.Dominio.Repositories
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Clientes>> GetAllAsync();
        Task<Clientes?> GetByIdAsync(Guid id);
        Task AddAsync(Clientes cliente);
        Task<bool> UpdateAsync(Clientes cliente);
        Task<bool> DeleteAsync(Guid id);
    }
}
