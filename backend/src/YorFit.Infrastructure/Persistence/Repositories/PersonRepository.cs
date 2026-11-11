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
