using YorFit.Domain.Entities;

namespace YorFit.Application.Contracts;

public interface IEmployeeRepository
{
    Task Agregar(Employee employee);
    Task<Employee?> ObtenerPorId(Guid id);
    Task<List<Employee>> ObtenerFiltrado(string? cargo, Guid? idPersona, bool? estado);
    Task Actualizar(Employee employee);
    Task Eliminar(Employee employee);
}
