using System;
using System.Collections.Generic;
using System.Text;
using YorFit.Application.Contracts;
using YorFit.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace YorFit.Infrastructure.Persistence.Repositories;

internal class RoleRepository(ApplicationDbContext context) : IRoleRepository
{
    public async Task Actualizar(Role role)
    {
        context.Update(role);
        await context.SaveChangesAsync();
    }

    public async Task Agregar(Role role)
    {
        context.Add(role);
        await context.SaveChangesAsync();
    }

    public async Task<bool> Existe(string nombre)
    {
        return await context.Roles.AnyAsync(x => x.Nombre == nombre);
    }

    public async Task<List<Role>> ObtenerFiltrado(string? nombre, bool? estado)
    {
        var query = context.Roles.AsNoTracking();

        if (!string.IsNullOrWhiteSpace(nombre))
        {
            var nombreFiltro = nombre.Trim();
            query = query.Where(branch => branch.Nombre.Contains(nombreFiltro));
        }

        if (estado.HasValue)
        {
            query = query.Where(branch => branch.Estado == estado.Value);
        }

        return await query.ToListAsync();
    }

    public async Task<Role?> ObtenerPorId(Guid id)
    {
        return await context.Roles.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task Eliminar(Role rol)
    {
        context.Roles.Remove(rol);
        await context.SaveChangesAsync();
    }
}