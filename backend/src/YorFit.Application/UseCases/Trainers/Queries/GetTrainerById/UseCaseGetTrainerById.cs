using YorFit.Application.Contracts;
using YorFit.Application.Exceptions;
using YorFit.Application.Utilities.Mediator;

namespace YorFit.Application.UseCases.Trainers.Queries.GetTrainerById;

public class UseCaseGetTrainerById(ITrainerRepository repository)
    : IRequestHandler<QueryGetTrainerById, TrainerDetailDTO>
{
    public async Task<TrainerDetailDTO> Handle(QueryGetTrainerById query)
    {
        var trainer = await repository.ObtenerPorId(query.Id)
            ?? throw new NotFoundException();

        return new TrainerDetailDTO(
            trainer.Id,
            trainer.IdEmpleado,
            trainer.Especialidad,
            trainer.Estado);
    }
}
