using YorFit.Application.Utilities.Mediator;

namespace YorFit.Application.UseCases.Members.Commands.DeleteMember;

public record DeleteMemberCommand(Guid Id) : IRequest;
