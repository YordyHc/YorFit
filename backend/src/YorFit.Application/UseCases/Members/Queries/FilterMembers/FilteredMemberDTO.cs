namespace YorFit.Application.UseCases.Members.Queries.FilterMembers;

public record FilteredMemberDTO(
    Guid Id,
    Guid IdPersona,
    string CodigoSocio,
    bool Estado
);
