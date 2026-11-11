namespace YorFit.Application.UseCases.Trainers.Queries.FilterTrainers;

public record FilteredTrainerDTO(
    Guid Id,
    Guid IdEmpleado,
    string Especialidad,
    bool Estado
);
