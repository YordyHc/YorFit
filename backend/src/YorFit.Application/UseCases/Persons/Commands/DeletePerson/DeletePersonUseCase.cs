using YorFit.Application.Contracts;
using YorFit.Application.Exceptions;
using YorFit.Application.Utilities.Mediator;

namespace YorFit.Application.UseCases.Persons.Commands.DeletePerson;

public class DeletePersonUseCase(IPersonRepository repository)
    : IRequestHandler<DeletePersonCommand>
{
    public async Task Handle(DeletePersonCommand command)
    {
        var person = await repository.ObtenerPorId(command.Id)
            ?? throw new NotFoundException();

        await repository.Eliminar(person);
    }
}
