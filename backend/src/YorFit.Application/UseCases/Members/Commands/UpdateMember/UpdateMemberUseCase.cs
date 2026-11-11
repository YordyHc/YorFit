using YorFit.Application.Contracts;
using YorFit.Application.Exceptions;
using YorFit.Application.Utilities.Mediator;
using YorFit.Domain.Exceptions;

namespace YorFit.Application.UseCases.Members.Commands.UpdateMember;

public class UpdateMemberUseCase(IMemberRepository repository)
    : IRequestHandler<UpdateMemberCommand>
{
    public async Task Handle(UpdateMemberCommand command)
    {
        var member = await repository.ObtenerPorId(command.Id)
            ?? throw new NotFoundException();

        var codigoSocio = command.CodigoSocio?.Trim();
        if (string.IsNullOrWhiteSpace(codigoSocio))
            throw new BusinessRuleException("El código de socio es obligatorio.");

        if (await repository.ExisteCodigoSocio(codigoSocio, member.Id))
            throw new BusinessRuleException($"Ya existe un socio con el código: {codigoSocio}");

        member.Actualizar(codigoSocio, command.FechaIngreso);
        await repository.Actualizar(member);
    }
}
