using YorFit.Domain.Entities;

namespace YorFit.Application.Contracts;

public interface IMemberRepository
{
    Task Agregar(Member member);
    Task<bool> ExisteCodigoSocio(string codigoSocio, Guid? excluirId = null);
    Task<Member?> ObtenerPorId(Guid id);
    Task<List<Member>> ObtenerFiltrado(string? codigoSocio, Guid? idPersona, bool? estado);
    Task Actualizar(Member member);
    Task Eliminar(Member member);
}
