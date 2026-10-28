using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using YorFit.Application.UseCases.Branchs.Commands.UpdateBranch;
using YorFit.Application.UseCases.Branchs.Commands.ChangeBranchStatus;
using YorFit.Application.UseCases.Branchs.Commands.CreateBranch;
using YorFit.Application.Utilities.Mediator;
using YorFit.Application.UseCases.Branchs.Queries.FilterBranchs;
using YorFit.Application.UseCases.Branchs.Queries.GetBranchById;
using YorFit.Application.UseCases.Branchs.Commands.DeleteBranch;

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

        services.AddScoped<IRequestHandler<FilterBranchsQuery, List<FilteredBranchDTO>>, FilterProductsUseCase>();

        services.AddScoped<IRequestHandler<DeleteBranchCommand>, DeleteBranchUseCase>();

        return services;
    }
}