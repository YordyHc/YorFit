using YorFit.Application.Utilities.Mediator;

namespace YorFit.Application.UseCases.Trainers.Commands.CreateTrainer;

public record CreateTrainerCommand(Guid IdEmpleado, string Especialidad) : IRequest<Guid>;
