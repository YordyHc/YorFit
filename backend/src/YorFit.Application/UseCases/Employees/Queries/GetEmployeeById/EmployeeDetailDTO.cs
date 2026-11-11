namespace YorFit.Application.UseCases.Employees.Queries.GetEmployeeById;

public record EmployeeDetailDTO(
    Guid Id,
    Guid IdPersona,
    string Cargo,
    decimal Sueldo,
    string Moneda,
    DateTime FechaIngreso,
    bool Estado
);
