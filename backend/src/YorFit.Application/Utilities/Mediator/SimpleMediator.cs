using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace YorFit.Application.Utilities.Mediator;

public class SimpleMediator(IServiceProvider sp): IMediator
{
    public async Task<TResponse> Send<TResponse>(IRequest<TResponse> request)
    {
        var tipoHandler = typeof(IRequestHandler<,>).MakeGenericType(request.GetType(), typeof(TResponse));
        var casoDeUso = sp.GetRequiredService(tipoHandler);
        var metodo = tipoHandler.GetMethod("Handle")!;
        
        return await (Task<TResponse>)metodo.Invoke(casoDeUso, new object[] { request })!;
    }
    
    public async Task Send(IRequest request)
    {
        var tipoHandler = typeof(IRequestHandler<>).MakeGenericType(request.GetType());

        var casoDeUso = sp.GetRequiredService(tipoHandler);
        var metodo = tipoHandler.GetMethod("Handle")!;

        await (Task)metodo.Invoke(casoDeUso, new object[] { request })!;
    }
}