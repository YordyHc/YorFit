using YorFit.Application.Utilities.Mediator;

namespace YorFit.Application.UseCases.Members.Queries.FilterMembers;

public record FilterMembersQuery(
    string? CodigoSocio,
    Guid? IdPersona,
    bool? Estado
) : IRequest<List<FilteredMemberDTO>>;
