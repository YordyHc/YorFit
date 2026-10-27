using System;
using System.Collections.Generic;
using System.Text;
using YorFit.Application.Contracts;
using YorFit.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace YorFit.Infrastructure.Persistence.Repositories;

internal class BranchRepository(ApplicationDbContext context) : IBranchRepository
{
    public async Task Actualizar(Branch branch)
    {
        context.Update(branch);
        await context.SaveChangesAsync();
    }

    public async Task Agregar(Branch branch)
    {
        context.Add(branch);
        await context.SaveChangesAsync();
    }

    public async Task<bool> Existe(string nombre)
    {
        return await context.Branchs.AnyAsync(x => x.Nombre == nombre);
    }

    public async Task<bool> ExisteCodigo(string codigo)
    {
        return await context.Branchs.AnyAsync(x => x.Codigo == codigo);
    }


    public async Task<List<Branch>> ObtenerFiltrado(string? nombre, bool? activo)
    {
        var queryable = context.Branchs.AsQueryable();

        if (nombre is not null)
        {
            queryable = queryable.Where(x => x.Nombre.Contains(nombre));
        }

        if (activo is not null)
        {
            queryable = queryable.Where(x => x.Activo == activo);
        }

        return await queryable.ToListAsync();
    }

    public async Task<Branch?> ObtenerPorId(Guid id)
    {
        return await context.Branchs.FirstOrDefaultAsync(x => x.Id == id);
    }
}