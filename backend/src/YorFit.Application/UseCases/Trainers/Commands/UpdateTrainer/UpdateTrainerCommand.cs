using YorFit.Application.Utilities.Mediator;

namespace YorFit.Application.UseCases.Trainers.Commands.UpdateTrainer;

public record UpdateTrainerCommand(Guid Id, string Especialidad) : IRequest;
