using DulceFacil.Dominio.Entities;

namespace DulceFacil.Dominio.Repositories
{
    public interface IZonaRepository
    {
        Task<IEnumerable<Zonas>> GetAllAsync();
        Task<Zonas?> GetByIdAsync(Guid id);
        Task AddAsync(Zonas zona);
        Task<bool> UpdateAsync(Zonas zona);
        Task<bool> DeleteAsync(Guid id);
    }
}
