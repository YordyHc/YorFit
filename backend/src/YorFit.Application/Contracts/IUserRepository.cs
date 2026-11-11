using YorFit.Domain.Entities;

namespace YorFit.Application.Contracts;

public interface IUserRepository
{
    Task Agregar(User user);
    Task<bool> ExisteNombreUsuario(string nombreUsuario, Guid? excluirId = null);
    Task<bool> ExisteEmail(string email, Guid? excluirId = null);
    Task<User?> ObtenerPorId(Guid id);
    Task<List<User>> ObtenerFiltrado(
        string? nombreUsuario,
        string? email,
        Guid? idSede,
        Guid? idRol,
        bool? estado);
    Task Actualizar(User user);
    Task Eliminar(User user);
}
