using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using YorFit.Application.UseCases.Branchs.Commands.UpdateBranch;
using YorFit.Application.UseCases.Branchs.Commands.ChangeBranchStatus;
using YorFit.Application.UseCases.Branchs.Commands.CreateBranch;
using YorFit.Application.Utilities.Mediator;
// using YorFit.Application.UseCases.Branchs.Queries.FiltrarProductos;
// using YorFit.Application.UseCases.Branchs.Queries.ObtenerProductoPorId;
//using YorFit.Application.Utilities.Mediator;

namespace YorFit.Application;

public static class DependencyInjection
{
    public static IServiceCollection AgregarAplicacion(this IServiceCollection services)
    {
        services.AddTransient<IMediator, SimpleMediator>();

        services.AddScoped<IRequestHandler<CreateBranchCommand, Guid>, CreateBranchUseCase>();

        services.AddScoped<IRequestHandler<UpdateBranchCommand>, UpdateBranchUseCase>();

        services.AddScoped<IRequestHandler<ChangeBranchStatusCommand>, ChangeBranchStatusUseCase>();
        
        // services.AddScoped<IRequestHandler<ConsultaObtenerProductoPorId, ProductoDetalleDTO>, CasoDeUsoObtenerProductoPorId>();

        // services.AddScoped<IRequestHandler<ConsultaFiltrarProductos, List<ProductoFiltradoDTO>>, CasoDeUsoFiltrarProducto>();
        return services;
    }
}