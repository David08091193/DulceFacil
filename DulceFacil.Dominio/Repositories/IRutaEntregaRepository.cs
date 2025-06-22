using DulceFacil.Dominio.Entities;

namespace DulceFacil.Dominio.Repositories
{
    public interface IRutaEntregaRepository
    {
        Task<IEnumerable<RutasEntrega>> GetAllAsync();
        Task<RutasEntrega?> GetByIdAsync(Guid id);
        Task AddAsync(RutasEntrega ruta);
        Task<bool> UpdateAsync(RutasEntrega ruta);
        Task<bool> DeleteAsync(Guid id);
    }
}
