using Microsoft.EntityFrameworkCore;
using YorFit.Application.Contracts;
using YorFit.Domain.Entities;
using YorFit.Domain.ValuableObjects;

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
        var emailValue = Email.Crear(email);
        return await context.Users.AnyAsync(user =>
            user.Email == emailValue &&
            (!excluirId.HasValue || user.Id != excluirId.Value));
    }

    public async Task<User?> ObtenerPorId(Guid id)
    {
        return await context.Users.FirstOrDefaultAsync(user => user.Id == id);
    }

    public async Task<List<User>> ObtenerFiltrado(
        string? nombreUsuario,
        string? email,
        Guid? idSede,
        Guid? idRol,
        bool? estado)
    {
        var query = context.Users.AsNoTracking();

        if (!string.IsNullOrWhiteSpace(nombreUsuario))
        {
            var filtro = nombreUsuario.Trim();
            query = query.Where(user => user.NombreUsuario.Contains(filtro));
        }

        if (!string.IsNullOrWhiteSpace(email))
        {
            var filtro = Email.Crear(email);
            query = query.Where(user => user.Email == filtro);
        }

        if (idSede.HasValue)
            query = query.Where(user => user.IdSede == idSede.Value);

        if (idRol.HasValue)
            query = query.Where(user => user.IdRol == idRol.Value);

        if (estado.HasValue)
            query = query.Where(user => user.Estado == estado.Value);

        return await query.ToListAsync();
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
