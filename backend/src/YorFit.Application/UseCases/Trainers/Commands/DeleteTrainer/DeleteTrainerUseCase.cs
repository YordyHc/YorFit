using YorFit.Application.Contracts;
using YorFit.Application.Exceptions;
using YorFit.Application.Utilities.Mediator;

namespace YorFit.Application.UseCases.Trainers.Commands.DeleteTrainer;

public class DeleteTrainerUseCase(ITrainerRepository repository)
    : IRequestHandler<DeleteTrainerCommand>
{
    public async Task Handle(DeleteTrainerCommand command)
    {
        var trainer = await repository.ObtenerPorId(command.Id)
            ?? throw new NotFoundException();

        await repository.Eliminar(trainer);
    }
}
