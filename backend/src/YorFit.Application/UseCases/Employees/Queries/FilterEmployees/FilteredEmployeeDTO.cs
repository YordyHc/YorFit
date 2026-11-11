namespace YorFit.Application.UseCases.Employees.Queries.FilterEmployees;

public record FilteredEmployeeDTO(
    Guid Id,
    Guid IdPersona,
    string Cargo,
    decimal Sueldo,
    string Moneda,
    bool Estado
);
