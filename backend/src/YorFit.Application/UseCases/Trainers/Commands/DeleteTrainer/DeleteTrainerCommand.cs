using YorFit.Application.Utilities.Mediator;

namespace YorFit.Application.UseCases.Trainers.Commands.DeleteTrainer;

public record DeleteTrainerCommand(Guid Id) : IRequest;
