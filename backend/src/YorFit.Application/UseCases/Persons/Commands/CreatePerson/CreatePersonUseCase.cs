using YorFit.Application.Contracts;
using YorFit.Application.Utilities.Mediator;
using YorFit.Domain.Entities;
using YorFit.Domain.ValuableObjects;

namespace YorFit.Application.UseCases.Persons.Commands.CreatePerson;

public class CreatePersonUseCase(IPersonRepository repository)
    : IRequestHandler<CreatePersonCommand, Guid>
{
    public async Task<Guid> Handle(CreatePersonCommand command)
    {
        var person = Person.Crear(
            command.Nombres,
            command.Apellidos,
            IdentityDocument.Crear(command.TipoDocumento, command.NumeroDocumento),
            Phone.Crear(command.NumeroNacional, command.CodigoPais),
            Address.Crear(
                command.LineaDireccion1,
                command.LineaDireccion2,
                command.Distrito,
                command.Provincia,
                command.Referencia,
                command.Pais),
            command.FechaNacimiento);

        await repository.Agregar(person);
        return person.Id;
    }
}
