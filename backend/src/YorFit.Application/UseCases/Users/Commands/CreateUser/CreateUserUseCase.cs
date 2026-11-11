using YorFit.Application.Contracts;
using YorFit.Application.Utilities.Mediator;
using YorFit.Domain.Entities;
using YorFit.Domain.Exceptions;
using YorFit.Domain.ValuableObjects;

namespace YorFit.Application.UseCases.Users.Commands.CreateUser;

public class CreateUserUseCase(IUserRepository repository)
    : IRequestHandler<CreateUserCommand, Guid>
{
    public async Task<Guid> Handle(CreateUserCommand command)
    {
        var nombreUsuario = command.NombreUsuario?.Trim();
        var email = Email.Crear(command.Email);

        if (string.IsNullOrWhiteSpace(nombreUsuario))
            throw new BusinessRuleException("El nombre de usuario es obligatorio.");

        if (await repository.ExisteNombreUsuario(nombreUsuario))
            throw new BusinessRuleException($"Ya existe un usuario con el nombre: {nombreUsuario}");

        if (await repository.ExisteEmail(email.Valor))
            throw new BusinessRuleException($"Ya existe un usuario con el correo: {email.Valor}");

        var user = User.Crear(
            command.IdPersona,
            command.IdSede,
            command.IdRol,
            nombreUsuario,
            email,
            command.PasswordHash,
            command.RequiereCambioPassword);

        await repository.Agregar(user);
        return user.Id;
    }
}
