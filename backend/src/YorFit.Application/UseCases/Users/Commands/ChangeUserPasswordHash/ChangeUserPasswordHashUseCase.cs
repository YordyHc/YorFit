using YorFit.Application.Contracts;
using YorFit.Application.Exceptions;
using YorFit.Application.Utilities.Mediator;

namespace YorFit.Application.UseCases.Users.Commands.ChangeUserPasswordHash;

public class ChangeUserPasswordHashUseCase(IUserRepository repository)
    : IRequestHandler<ChangeUserPasswordHashCommand>
{
    public async Task Handle(ChangeUserPasswordHashCommand command)
    {
        var user = await repository.ObtenerPorId(command.Id)
            ?? throw new NotFoundException();

        user.ActualizarPasswordHash(command.PasswordHash, command.RequiereCambioPassword);
        await repository.Actualizar(user);
    }
}
