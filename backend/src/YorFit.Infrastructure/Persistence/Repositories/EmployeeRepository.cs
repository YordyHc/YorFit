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
