using YorFit.Application.Utilities.Mediator;

namespace YorFit.Application.UseCases.Employees.Queries.GetEmployeeById;

public record QueryGetEmployeeById(Guid Id) : IRequest<EmployeeDetailDTO>;
