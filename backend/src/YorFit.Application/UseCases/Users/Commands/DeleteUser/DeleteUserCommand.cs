using YorFit.Application.Utilities.Mediator;

namespace YorFit.Application.UseCases.Users.Commands.DeleteUser;

public record DeleteUserCommand(Guid Id) : IRequest;
