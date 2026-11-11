using YorFit.Application.Utilities.Mediator;

namespace YorFit.Application.UseCases.Employees.Commands.DeleteEmployee;

public record DeleteEmployeeCommand(Guid Id) : IRequest;
