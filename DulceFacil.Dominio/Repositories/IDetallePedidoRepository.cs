using DulceFacil.Dominio.Entities;

namespace DulceFacil.Dominio.Repositories
{
    public interface IDetallePedidoRepository
    {
        Task<IEnumerable<DetallePedidos>> GetAllAsync();
        Task<DetallePedidos?> GetByIdAsync(Guid id);
        Task AddAsync(DetallePedidos detalle);
        Task<bool> UpdateAsync(DetallePedidos detalle);
        Task<bool> DeleteAsync(Guid id);
    }
}
