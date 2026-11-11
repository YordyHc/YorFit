using YorFit.Application.Utilities.Mediator;

namespace YorFit.Application.UseCases.Employees.Commands.UpdateEmployee;

public record UpdateEmployeeCommand(
    Guid Id,
    string Cargo,
    decimal Sueldo,
    string Moneda,
    DateTime FechaIngreso
) : IRequest;
