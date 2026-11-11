using YorFit.Application.Utilities.Mediator;

namespace YorFit.Application.UseCases.Members.Queries.GetMemberById;

public record QueryGetMemberById(Guid Id) : IRequest<MemberDetailDTO>;
