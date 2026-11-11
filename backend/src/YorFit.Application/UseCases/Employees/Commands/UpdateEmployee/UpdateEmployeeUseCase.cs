using YorFit.Application.Contracts;
using YorFit.Application.Exceptions;
using YorFit.Application.Utilities.Mediator;
using YorFit.Domain.ValuableObjects;

namespace YorFit.Application.UseCases.Employees.Commands.UpdateEmployee;

public class UpdateEmployeeUseCase(IEmployeeRepository repository)
    : IRequestHandler<UpdateEmployeeCommand>
{
    public async Task Handle(UpdateEmployeeCommand command)
    {
        var employee = await repository.ObtenerPorId(command.Id)
            ?? throw new NotFoundException();

        employee.Actualizar(
            command.Cargo,
            Money.Crear(command.Sueldo, command.Moneda),
            command.FechaIngreso);

        await repository.Actualizar(employee);
    }
}
