using DulceFacil.Dominio.Entities;

namespace DulceFacil.Dominio.Repositories
{
    public interface IPedidoRepository
    {
        Task<IEnumerable<Pedidos>> GetAllAsync();
        Task<Pedidos?> GetByIdAsync(Guid id);
        Task AddAsync(Pedidos pedido);
        Task<bool> UpdateAsync(Pedidos pedido);
        Task<bool> DeleteAsync(Guid id);
    }
}
