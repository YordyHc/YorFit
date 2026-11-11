using YorFit.Application.Utilities.Mediator;

namespace YorFit.Application.UseCases.Users.Commands.CreateUser;

public record CreateUserCommand(
    Guid IdPersona,
    Guid IdSede,
    Guid IdRol,
    string NombreUsuario,
    string Email,
    string PasswordHash,
    bool RequiereCambioPassword
) : IRequest<Guid>;
