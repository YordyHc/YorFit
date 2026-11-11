using YorFit.Application.Utilities.Mediator;

namespace YorFit.Application.UseCases.Employees.Commands.CreateEmployee;

public record CreateEmployeeCommand(
    Guid IdPersona,
    string Cargo,
    decimal Sueldo,
    string Moneda,
    DateTime FechaIngreso
) : IRequest<Guid>;
