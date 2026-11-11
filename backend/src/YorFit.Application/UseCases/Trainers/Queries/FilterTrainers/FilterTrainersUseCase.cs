using YorFit.Application.Contracts;
using YorFit.Application.Utilities.Mediator;

namespace YorFit.Application.UseCases.Trainers.Queries.FilterTrainers;

public class FilterTrainersUseCase(ITrainerRepository repository)
    : IRequestHandler<FilterTrainersQuery, List<FilteredTrainerDTO>>
{
    public async Task<List<FilteredTrainerDTO>> Handle(FilterTrainersQuery query)
    {
        var trainers = await repository.ObtenerFiltrado(
            query.Especialidad,
            query.IdEmpleado,
            query.Estado);

        return trainers.Select(trainer => new FilteredTrainerDTO(
            trainer.Id,
            trainer.IdEmpleado,
            trainer.Especialidad,
            trainer.Estado)).ToList();
    }
}
