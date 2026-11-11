using YorFit.Application.Utilities.Mediator;

namespace YorFit.Application.UseCases.Members.Commands.CreateMember;

public record CreateMemberCommand(
    Guid IdPersona,
    string CodigoSocio,
    DateTime FechaIngreso
) : IRequest<Guid>;
