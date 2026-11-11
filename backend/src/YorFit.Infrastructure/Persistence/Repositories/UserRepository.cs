using Microsoft.EntityFrameworkCore;
using YorFit.Application.Contracts;
using YorFit.Domain.Entities;

namespace YorFit.Infrastructure.Persistence.Repositories;

internal class UserRepository(ApplicationDbContext context) : IUserRepository
{
    public async Task Agregar(User user)
    {
        context.Add(user);
        await context.SaveChangesAsync();
    }

    public async Task<bool> ExisteNombreUsuario(string nombreUsuario, Guid? excluirId = null)
    {
        return await context.Users.AnyAsync(user =>
            user.NombreUsuario == nombreUsuario &&
            (!excluirId.HasValue || user.Id != excluirId.Value));
    }

    public async Task<bool> ExisteEmail(string email, Guid? excluirId = null)
    {
        return await context.Users.AnyAsync(user =>
            user.Email.Valor == email &&
            (!excluirId.HasValue || user.Id != excluirId.Value));
    }

    public async Task<User?> ObtenerPorId(Guid id)
    {
        return await context.Users.FirstOrDefaultAsync(user => user.Id == id);
    }

    public async Task Actualizar(User user)
    {
        context.Update(user);
        await context.SaveChangesAsync();
    }

    public async Task Eliminar(User user)
    {
        context.Users.Remove(user);
        await context.SaveChangesAsync();
    }
}
