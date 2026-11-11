using YorFit.Application.Utilities.Mediator;

namespace YorFit.Application.UseCases.Trainers.Queries.FilterTrainers;

public record FilterTrainersQuery(
    string? Especialidad,
    Guid? IdEmpleado,
    bool? Estado
) : IRequest<List<FilteredTrainerDTO>>;
