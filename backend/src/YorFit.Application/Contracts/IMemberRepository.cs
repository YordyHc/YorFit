using YorFit.Domain.Entities;

namespace YorFit.Application.Contracts;

public interface IMemberRepository
{
    Task Agregar(Member member);
    Task<bool> ExisteCodigoSocio(string codigoSocio, Guid? excluirId = null);
    Task<Member?> ObtenerPorId(Guid id);
    Task Actualizar(Member member);
    Task Eliminar(Member member);
}
