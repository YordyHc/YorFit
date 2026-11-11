namespace YorFit.Application.UseCases.Users.Queries.GetUserById;

public record UserDetailDTO(
    Guid Id,
    Guid IdPersona,
    Guid IdSede,
    Guid IdRol,
    string NombreUsuario,
    string Email,
    bool Estado,
    bool RequiereCambioPassword
);
