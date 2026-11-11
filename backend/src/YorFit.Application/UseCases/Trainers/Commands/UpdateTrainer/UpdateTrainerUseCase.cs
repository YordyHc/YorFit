using YorFit.Application.Contracts;
using YorFit.Application.Exceptions;
using YorFit.Application.Utilities.Mediator;

namespace YorFit.Application.UseCases.Trainers.Commands.UpdateTrainer;

public class UpdateTrainerUseCase(ITrainerRepository repository)
    : IRequestHandler<UpdateTrainerCommand>
{
    public async Task Handle(UpdateTrainerCommand command)
    {
        var trainer = await repository.ObtenerPorId(command.Id)
            ?? throw new NotFoundException();

        trainer.Actualizar(command.Especialidad);
        await repository.Actualizar(trainer);
    }
}
