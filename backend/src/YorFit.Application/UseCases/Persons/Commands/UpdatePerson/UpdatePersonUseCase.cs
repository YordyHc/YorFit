using YorFit.Application.Contracts;
using YorFit.Application.Exceptions;
using YorFit.Application.Utilities.Mediator;
using YorFit.Domain.ValuableObjects;

namespace YorFit.Application.UseCases.Persons.Commands.UpdatePerson;

public class UpdatePersonUseCase(IPersonRepository repository)
    : IRequestHandler<UpdatePersonCommand>
{
    public async Task Handle(UpdatePersonCommand command)
    {
        var person = await repository.ObtenerPorId(command.Id)
            ?? throw new NotFoundException();

        person.Actualizar(
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

        await repository.Actualizar(person);
    }
}
