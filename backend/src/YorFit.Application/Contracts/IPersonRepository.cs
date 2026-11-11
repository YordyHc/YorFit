using YorFit.Domain.Entities;

namespace YorFit.Application.Contracts;

public interface IPersonRepository
{
    Task Agregar(Person person);
    Task<Person?> ObtenerPorId(Guid id);
    Task<List<Person>> ObtenerFiltrado(string? nombres, string? apellidos, string? numeroDocumento, bool? activo);
    Task Actualizar(Person person);
    Task Eliminar(Person person);
}
