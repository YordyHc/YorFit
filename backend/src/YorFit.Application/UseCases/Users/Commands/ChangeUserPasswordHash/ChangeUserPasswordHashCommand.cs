using YorFit.Application.Utilities.Mediator;

namespace YorFit.Application.UseCases.Users.Commands.ChangeUserPasswordHash;

public record ChangeUserPasswordHashCommand(
    Guid Id,
    string PasswordHash,
    bool RequiereCambioPassword
) : IRequest;
