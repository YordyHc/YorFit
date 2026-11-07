using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using YorFit.Application.Utilities.Mediator;
//sede
using YorFit.Application.UseCases.Branchs.Commands.UpdateBranch;
using YorFit.Application.UseCases.Branchs.Commands.ChangeBranchStatus;
using YorFit.Application.UseCases.Branchs.Commands.CreateBranch;
using YorFit.Application.UseCases.Branchs.Queries.FilterBranchs;
using YorFit.Application.UseCases.Branchs.Queries.GetBranchById;
using YorFit.Application.UseCases.Branchs.Commands.DeleteBranch;
//rol
using YorFit.Application.UseCases.Roles.Commands.CreateRole;
using YorFit.Application.UseCases.Roles.Commands.UpdateRole;
using YorFit.Application.UseCases.Roles.Commands.ChangeRoleStatus;
using YorFit.Application.UseCases.Roles.Commands.DeleteRole;
using YorFit.Application.UseCases.Roles.Queries.GetRoleById;
using YorFit.Application.UseCases.Roles.Queries.FilterRoles;

namespace YorFit.Application;

public static class DependencyInjection
{
    public static IServiceCollection AgregarAplicacion(this IServiceCollection services)
    {
        services.AddTransient<IMediator, SimpleMediator>();

        services.AddScoped<IRequestHandler<CreateBranchCommand, Guid>, CreateBranchUseCase>();

        services.AddScoped<IRequestHandler<UpdateBranchCommand>, UpdateBranchUseCase>();

        services.AddScoped<IRequestHandler<ChangeBranchStatusCommand>, ChangeBranchStatusUseCase>();
        
        services.AddScoped<IRequestHandler<QueryGetBranchById, BranchDetailDTO>, UseCaseGetBranchById>();

        services.AddScoped<IRequestHandler<FilterBranchsQuery, List<FilteredBranchDTO>>, FilterBranchsUseCase>();

        services.AddScoped<IRequestHandler<DeleteBranchCommand>, DeleteBranchUseCase>();

        //rol

        services.AddScoped<IRequestHandler<CreateRoleCommand, Guid>, CreateRoleUseCase>();

        services.AddScoped<IRequestHandler<UpdateRoleCommand>, UpdateRoleUseCase>();

        services.AddScoped<IRequestHandler<ChangeRoleStatusCommand>, ChangeRoleStatusUseCase>();
        
        services.AddScoped<IRequestHandler<QueryGetRoleById, RoleDetailDTO>, UseCaseGetRoleById>();

        services.AddScoped<IRequestHandler<FilterRolesQuery, List<FilteredRoleDTO>>, FilterRolesUseCase>();

        services.AddScoped<IRequestHandler<DeleteRoleCommand>, DeleteRoleUseCase>();
        return services;
    }
}