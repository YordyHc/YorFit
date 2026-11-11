using Microsoft.EntityFrameworkCore;
using YorFit.Application.Contracts;
using YorFit.Domain.Entities;

namespace YorFit.Infrastructure.Persistence.Repositories;

internal class EmployeeRepository(ApplicationDbContext context) : IEmployeeRepository
{
    public async Task Agregar(Employee employee)
    {
        context.Add(employee);
        await context.SaveChangesAsync();
    }

    public async Task<Employee?> ObtenerPorId(Guid id)
    {
        return await context.Employees.FirstOrDefaultAsync(employee => employee.Id == id);
    }

    public async Task<List<Employee>> ObtenerFiltrado(string? cargo, Guid? idPersona, bool? estado)
    {
        var query = context.Employees.AsNoTracking();

        if (!string.IsNullOrWhiteSpace(cargo))
        {
            var filtro = cargo.Trim();
            query = query.Where(employee => employee.Cargo.Contains(filtro));
        }

        if (idPersona.HasValue)
            query = query.Where(employee => employee.IdPersona == idPersona.Value);

        if (estado.HasValue)
            query = query.Where(employee => employee.Estado == estado.Value);

        return await query.ToListAsync();
    }

    public async Task Actualizar(Employee employee)
    {
        context.Update(employee);
        await context.SaveChangesAsync();
    }

    public async Task Eliminar(Employee employee)
    {
        context.Employees.Remove(employee);
        await context.SaveChangesAsync();
    }
}
