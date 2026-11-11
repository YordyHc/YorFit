using YorFit.Application.Contracts;
using YorFit.Application.Utilities.Mediator;

namespace YorFit.Application.UseCases.Members.Queries.FilterMembers;

public class FilterMembersUseCase(IMemberRepository repository)
    : IRequestHandler<FilterMembersQuery, List<FilteredMemberDTO>>
{
    public async Task<List<FilteredMemberDTO>> Handle(FilterMembersQuery query)
    {
        var members = await repository.ObtenerFiltrado(
            query.CodigoSocio,
            query.IdPersona,
            query.Estado);

        return members.Select(member => new FilteredMemberDTO(
            member.Id,
            member.IdPersona,
            member.CodigoSocio,
            member.Estado)).ToList();
    }
}
