using YorFit.Application.Utilities.Mediator;

namespace YorFit.Application.UseCases.Members.Commands.UpdateMember;

public record UpdateMemberCommand(
    Guid Id,
    string CodigoSocio,
    DateTime FechaIngreso
) : IRequest;
