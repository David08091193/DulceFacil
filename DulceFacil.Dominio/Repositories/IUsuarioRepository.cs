using DulceFacil.Dominio.Entities;
using DulceFacil.Infrastructura.Persistence;

namespace DulceFacil.Dominio.Repositories
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuarios>> GetAllAsync();
        Task<Usuarios?> GetByIdAsync(Guid id);
        Task AddAsync(Usuarios usuario);
        Task<bool> UpdateAsync(Usuarios usuario);
        Task<bool> DeleteAsync(Guid id);
    }
}
