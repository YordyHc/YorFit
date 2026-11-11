using YorFit.Domain.Entities;

namespace YorFit.Application.Contracts;

public interface IEmployeeRepository
{
    Task Agregar(Employee employee);
    Task<Employee?> ObtenerPorId(Guid id);
    Task Actualizar(Employee employee);
    Task Eliminar(Employee employee);
}
