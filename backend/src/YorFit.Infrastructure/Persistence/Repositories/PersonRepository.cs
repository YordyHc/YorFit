using Microsoft.EntityFrameworkCore;
using YorFit.Application.Contracts;
using YorFit.Domain.Entities;

namespace YorFit.Infrastructure.Persistence.Repositories;

internal class PersonRepository(ApplicationDbContext context) : IPersonRepository
{
    public async Task Agregar(Person person)
    {
        context.Add(person);
        await context.SaveChangesAsync();
    }

    public async Task<Person?> ObtenerPorId(Guid id)
    {
        return await context.Persons.FirstOrDefaultAsync(person => person.Id == id);
    }

    public async Task<List<Person>> ObtenerFiltrado(
        string? nombres,
        string? apellidos,
        string? numeroDocumento,
        bool? activo)
    {
        var query = context.Persons.AsNoTracking();

        if (!string.IsNullOrWhiteSpace(nombres))
        {
            var filtro = nombres.Trim();
            query = query.Where(person => person.Nombres.Contains(filtro));
        }

        if (!string.IsNullOrWhiteSpace(apellidos))
        {
            var filtro = apellidos.Trim();
            query = query.Where(person => person.Apellidos.Contains(filtro));
        }

        if (!string.IsNullOrWhiteSpace(numeroDocumento))
        {
            var filtro = numeroDocumento.Trim();
            query = query.Where(person => person.DocumentoIdentidad.Numero.Contains(filtro));
        }

        if (activo.HasValue)
            query = query.Where(person => person.Activo == activo.Value);

        return await query.ToListAsync();
    }

    public async Task Actualizar(Person person)
    {
        context.Update(person);
        await context.SaveChangesAsync();
    }

    public async Task Eliminar(Person person)
    {
        context.Persons.Remove(person);
        await context.SaveChangesAsync();
    }
}
