using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
// using YorFit.Application.UseCases.Branch.Commands.ActualizarProducto;
// using YorFit.Application.UseCases.Branch.Commands.AjusteInventario;
using YorFit.Application.UseCases.Branch.Commands.CreateBranch;
using YorFit.Application.Utilities.Mediator;
// using YorFit.Application.UseCases.Branch.Inquiries.FiltrarProductos;
// using YorFit.Application.UseCases.Branch.Inquiries.ObtenerProductoPorId;
// using YorFit.Application.Utilidades.Mediador;

namespace YorFit.Application;

public static class DependencyInjection
{
    public static IServiceCollection AgregarAplicacion(this IServiceCollection services)
    {
        services.AddTransient<IMediator, SimpleMediator>();

        services.AddScoped<IRequestHandler<CreateBranchCommand, Guid>, CreateBranchUseCase>();

        // services.AddScoped<IRequestHandler<ComandoActualizarProducto>, CasoDeUsoActualizarProducto>();

        // services.AddScoped<IRequestHandler<ComandoAjusteInventario>, CasoDeUsoAjusteInventario>();
        
        // services.AddScoped<IRequestHandler<ConsultaObtenerProductoPorId, ProductoDetalleDTO>, CasoDeUsoObtenerProductoPorId>();

        // services.AddScoped<IRequestHandler<ConsultaFiltrarProductos, List<ProductoFiltradoDTO>>, CasoDeUsoFiltrarProducto>();
        return services;
    }
}