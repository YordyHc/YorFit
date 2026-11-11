using YorFit.Application.Utilities.Mediator;
using YorFit.Domain.ValuableObjects;

namespace YorFit.Application.UseCases.Persons.Commands.CreatePerson;

public record CreatePersonCommand(
    string Nombres,
    string Apellidos,
    IdentityDocumentType TipoDocumento,
    string NumeroDocumento,
    string CodigoPais,
    string NumeroNacional,
    string LineaDireccion1,
    string? LineaDireccion2,
    string Distrito,
    string Provincia,
    string? Referencia,
    string Pais,
    DateTime FechaNacimiento
) : IRequest<Guid>;
