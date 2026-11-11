namespace YorFit.Application.UseCases.Trainers.Queries.GetTrainerById;

public record TrainerDetailDTO(
    Guid Id,
    Guid IdEmpleado,
    string Especialidad,
    bool Estado
);
