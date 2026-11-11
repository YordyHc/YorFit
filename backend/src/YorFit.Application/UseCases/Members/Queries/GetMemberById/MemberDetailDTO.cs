namespace YorFit.Application.UseCases.Members.Queries.GetMemberById;

public record MemberDetailDTO(
    Guid Id,
    Guid IdPersona,
    string CodigoSocio,
    DateTime FechaIngreso,
    bool Estado
);
