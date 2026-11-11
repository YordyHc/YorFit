using YorFit.Application.Contracts;
using YorFit.Application.Exceptions;
using YorFit.Application.Utilities.Mediator;

namespace YorFit.Application.UseCases.Employees.Queries.GetEmployeeById;

public class UseCaseGetEmployeeById(IEmployeeRepository repository)
    : IRequestHandler<QueryGetEmployeeById, EmployeeDetailDTO>
{
    public async Task<EmployeeDetailDTO> Handle(QueryGetEmployeeById query)
    {
        var employee = await repository.ObtenerPorId(query.Id)
            ?? throw new NotFoundException();

        return new EmployeeDetailDTO(
            employee.Id,
            employee.IdPersona,
            employee.Cargo,
            employee.Sueldo.Amount,
            employee.Sueldo.Currency,
            employee.FechaIngreso,
            employee.Estado);
    }
}
