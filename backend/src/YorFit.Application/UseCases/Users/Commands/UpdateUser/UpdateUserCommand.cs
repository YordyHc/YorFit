using YorFit.Application.Utilities.Mediator;

namespace YorFit.Application.UseCases.Users.Commands.UpdateUser;

public record UpdateUserCommand(
    Guid Id,
    Guid IdSede,
    Guid IdRol,
    string NombreUsuario,
    string Email
) : IRequest;
