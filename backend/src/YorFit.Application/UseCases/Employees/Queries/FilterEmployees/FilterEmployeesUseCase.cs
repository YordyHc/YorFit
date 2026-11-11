using YorFit.Application.Contracts;
using YorFit.Application.Utilities.Mediator;

namespace YorFit.Application.UseCases.Employees.Queries.FilterEmployees;

public class FilterEmployeesUseCase(IEmployeeRepository repository)
    : IRequestHandler<FilterEmployeesQuery, List<FilteredEmployeeDTO>>
{
    public async Task<List<FilteredEmployeeDTO>> Handle(FilterEmployeesQuery query)
    {
        var employees = await repository.ObtenerFiltrado(
            query.Cargo,
            query.IdPersona,
            query.Estado);

        return employees.Select(employee => new FilteredEmployeeDTO(
            employee.Id,
            employee.IdPersona,
            employee.Cargo,
            employee.Sueldo.Amount,
            employee.Sueldo.Currency,
            employee.Estado)).ToList();
    }
}
