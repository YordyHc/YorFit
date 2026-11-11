using YorFit.Application.Contracts;
using YorFit.Application.Exceptions;
using YorFit.Application.Utilities.Mediator;

namespace YorFit.Application.UseCases.Users.Commands.DeleteUser;

public class DeleteUserUseCase(IUserRepository repository)
    : IRequestHandler<DeleteUserCommand>
{
    public async Task Handle(DeleteUserCommand command)
    {
        var user = await repository.ObtenerPorId(command.Id)
            ?? throw new NotFoundException();

        await repository.Eliminar(user);
    }
}
