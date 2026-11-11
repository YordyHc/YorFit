using YorFit.Application.Utilities.Mediator;

namespace YorFit.Application.UseCases.Users.Queries.GetUserById;

public record QueryGetUserById(Guid Id) : IRequest<UserDetailDTO>;
