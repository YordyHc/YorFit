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


    public async Task<List<Branch>> ObtenerFiltrado(string? nombre, string? codigo, bool? activo)
    {
        var query = context.Branchs.AsNoTracking();

        if (!string.IsNullOrWhiteSpace(nombre))
        {
            var nombreFiltro = nombre.Trim();
            query = query.Where(branch => branch.Nombre.Contains(nombreFiltro));
        }

        if (!string.IsNullOrWhiteSpace(codigo))
        {
            var codigoFiltro = codigo.Trim();
            query = query.Where(branch => branch.Codigo.Contains(codigoFiltro));
        }

        if (activo.HasValue)
        {
            query = query.Where(branch => branch.Activo == activo.Value);
        }

        return await query.ToListAsync();
    }

    public async Task<Branch?> ObtenerPorId(Guid id)
    {
        return await context.Branchs.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task Eliminar(Branch sede)
    {
        context.Branchs.Remove(sede);
        await context.SaveChangesAsync();
    }
}