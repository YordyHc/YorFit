using YorFit.Application.Contracts;
using YorFit.Application.Utilities.Mediator;
using YorFit.Domain.Entities;
using YorFit.Domain.ValuableObjects;

namespace YorFit.Application.UseCases.Employees.Commands.CreateEmployee;

public class CreateEmployeeUseCase(IEmployeeRepository repository)
    : IRequestHandler<CreateEmployeeCommand, Guid>
{
    public async Task<Guid> Handle(CreateEmployeeCommand command)
    {
        var employee = Employee.Crear(
            command.IdPersona,
            command.Cargo,
            Money.Crear(command.Sueldo, command.Moneda),
            command.FechaIngreso);

        await repository.Agregar(employee);
        return employee.Id;
    }
}
