using YorFit.Application.Contracts;
using YorFit.Application.Exceptions;
using YorFit.Application.Utilities.Mediator;
using YorFit.Domain.Exceptions;
using YorFit.Domain.ValuableObjects;

namespace YorFit.Application.UseCases.Users.Commands.UpdateUser;

public class UpdateUserUseCase(IUserRepository repository)
    : IRequestHandler<UpdateUserCommand>
{
    public async Task Handle(UpdateUserCommand command)
    {
        var user = await repository.ObtenerPorId(command.Id)
            ?? throw new NotFoundException();

        var nombreUsuario = command.NombreUsuario?.Trim();
        var email = Email.Crear(command.Email);

        if (string.IsNullOrWhiteSpace(nombreUsuario))
            throw new BusinessRuleException("El nombre de usuario es obligatorio.");

        if (await repository.ExisteNombreUsuario(nombreUsuario, user.Id))
            throw new BusinessRuleException($"Ya existe un usuario con el nombre: {nombreUsuario}");

        if (await repository.ExisteEmail(email.Valor, user.Id))
            throw new BusinessRuleException($"Ya existe un usuario con el correo: {email.Valor}");

        user.Actualizar(command.IdSede, command.IdRol, nombreUsuario, email);
        await repository.Actualizar(user);
    }
}
