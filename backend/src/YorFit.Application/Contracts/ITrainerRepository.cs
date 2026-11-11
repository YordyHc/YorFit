using YorFit.Domain.Entities;

namespace YorFit.Application.Contracts;

public interface ITrainerRepository
{
    Task Agregar(Trainer trainer);
    Task<Trainer?> ObtenerPorId(Guid id);
    Task<List<Trainer>> ObtenerFiltrado(string? especialidad, Guid? idEmpleado, bool? estado);
    Task Actualizar(Trainer trainer);
    Task Eliminar(Trainer trainer);
}
