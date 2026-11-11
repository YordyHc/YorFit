using YorFit.Application.Utilities.Mediator;

namespace YorFit.Application.UseCases.Persons.Queries.FilterPersons;

public record FilterPersonsQuery(
    string? Nombres,
    string? Apellidos,
    string? NumeroDocumento,
    bool? Activo
) : IRequest<List<FilteredPersonDTO>>;
