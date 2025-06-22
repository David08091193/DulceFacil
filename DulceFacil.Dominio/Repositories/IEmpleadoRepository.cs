using DulceFacil.Dominio.Entities;

namespace DulceFacil.Dominio.Repositories
{
    public interface IEmpleadoRepository
    {
        Task<IEnumerable<Empleados>> GetAllAsync();
        Task<Empleados?> GetByIdAsync(Guid id);
        Task AddAsync(Empleados empleado);
        Task<bool> UpdateAsync(Empleados empleado);
        Task<bool> DeleteAsync(Guid id);
    }
}
