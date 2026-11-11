using Microsoft.EntityFrameworkCore;
using YorFit.Application.Contracts;
using YorFit.Domain.Entities;

namespace YorFit.Infrastructure.Persistence.Repositories;

internal class TrainerRepository(ApplicationDbContext context) : ITrainerRepository
{
    public async Task Agregar(Trainer trainer)
    {
        context.Add(trainer);
        await context.SaveChangesAsync();
    }

    public async Task<Trainer?> ObtenerPorId(Guid id)
    {
        return await context.Trainers.FirstOrDefaultAsync(trainer => trainer.Id == id);
    }

    public async Task<List<Trainer>> ObtenerFiltrado(string? especialidad, Guid? idEmpleado, bool? estado)
    {
        var query = context.Trainers.AsNoTracking();

        if (!string.IsNullOrWhiteSpace(especialidad))
        {
            var filtro = especialidad.Trim();
            query = query.Where(trainer => trainer.Especialidad.Contains(filtro));
        }

        if (idEmpleado.HasValue)
            query = query.Where(trainer => trainer.IdEmpleado == idEmpleado.Value);

        if (estado.HasValue)
            query = query.Where(trainer => trainer.Estado == estado.Value);

        return await query.ToListAsync();
    }

    public async Task Actualizar(Trainer trainer)
    {
        context.Update(trainer);
        await context.SaveChangesAsync();
    }

    public async Task Eliminar(Trainer trainer)
    {
        context.Trainers.Remove(trainer);
        await context.SaveChangesAsync();
    }
}
