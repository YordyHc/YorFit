using YorFit.Domain.ValuableObjects;

namespace YorFit.Application.UseCases.Persons.Queries.FilterPersons;

public record FilteredPersonDTO(
    Guid Id,
    string Nombres,
    string Apellidos,
    IdentityDocumentType TipoDocumento,
    string NumeroDocumento,
    bool Activo
);
