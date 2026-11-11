namespace YorFit.Application.UseCases.Users.Queries.FilterUsers;

public record FilteredUserDTO(
    Guid Id,
    Guid IdPersona,
    Guid IdSede,
    Guid IdRol,
    string NombreUsuario,
    string Email,
    bool Estado
);
