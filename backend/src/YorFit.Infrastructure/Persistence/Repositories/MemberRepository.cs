using Microsoft.EntityFrameworkCore;
using YorFit.Application.Contracts;
using YorFit.Domain.Entities;

namespace YorFit.Infrastructure.Persistence.Repositories;

internal class MemberRepository(ApplicationDbContext context) : IMemberRepository
{
    public async Task Agregar(Member member)
    {
        context.Add(member);
        await context.SaveChangesAsync();
    }

    public async Task<bool> ExisteCodigoSocio(string codigoSocio, Guid? excluirId = null)
    {
        return await context.Members.AnyAsync(member =>
            member.CodigoSocio == codigoSocio &&
            (!excluirId.HasValue || member.Id != excluirId.Value));
    }

    public async Task<Member?> ObtenerPorId(Guid id)
    {
        return await context.Members.FirstOrDefaultAsync(member => member.Id == id);
    }

    public async Task Actualizar(Member member)
    {
        context.Update(member);
        await context.SaveChangesAsync();
    }

    public async Task Eliminar(Member member)
    {
        context.Members.Remove(member);
        await context.SaveChangesAsync();
    }
}
