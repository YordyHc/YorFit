using YorFit.Application.Contracts;
using YorFit.Application.Utilities.Mediator;
using YorFit.Domain.Entities;

namespace YorFit.Application.UseCases.Trainers.Commands.CreateTrainer;

public class CreateTrainerUseCase(ITrainerRepository repository)
    : IRequestHandler<CreateTrainerCommand, Guid>
{
    public async Task<Guid> Handle(CreateTrainerCommand command)
    {
        var trainer = Trainer.Crear(command.IdEmpleado, command.Especialidad);
        await repository.Agregar(trainer);
        return trainer.Id;
    }
}
