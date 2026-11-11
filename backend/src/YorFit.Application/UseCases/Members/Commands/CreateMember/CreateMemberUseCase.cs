using YorFit.Application.Contracts;
using YorFit.Application.Utilities.Mediator;
using YorFit.Domain.Entities;
using YorFit.Domain.Exceptions;

namespace YorFit.Application.UseCases.Members.Commands.CreateMember;

public class CreateMemberUseCase(IMemberRepository repository)
    : IRequestHandler<CreateMemberCommand, Guid>
{
    public async Task<Guid> Handle(CreateMemberCommand command)
    {
        var codigoSocio = command.CodigoSocio?.Trim();
        if (string.IsNullOrWhiteSpace(codigoSocio))
            throw new BusinessRuleException("El código de socio es obligatorio.");

        if (await repository.ExisteCodigoSocio(codigoSocio))
            throw new BusinessRuleException($"Ya existe un socio con el código: {codigoSocio}");

        var member = Member.Crear(command.IdPersona, codigoSocio, command.FechaIngreso);
        await repository.Agregar(member);
        return member.Id;
    }
}
