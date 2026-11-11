using YorFit.Application.Utilities.Mediator;

namespace YorFit.Application.UseCases.Employees.Queries.FilterEmployees;

public record FilterEmployeesQuery(
    string? Cargo,
    Guid? IdPersona,
    bool? Estado
) : IRequest<List<FilteredEmployeeDTO>>;
