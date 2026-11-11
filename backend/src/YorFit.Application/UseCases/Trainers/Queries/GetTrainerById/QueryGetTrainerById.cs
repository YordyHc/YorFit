using YorFit.Application.Utilities.Mediator;

namespace YorFit.Application.UseCases.Trainers.Queries.GetTrainerById;

public record QueryGetTrainerById(Guid Id) : IRequest<TrainerDetailDTO>;
