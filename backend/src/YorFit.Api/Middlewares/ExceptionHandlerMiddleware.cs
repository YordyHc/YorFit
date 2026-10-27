using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.Json;
using YorFit.Application.Exceptions;
using YorFit.Domain.Exceptions;

namespace YorFit.Api.Middlewares;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await ManejarExcepcion(context, ex);
        }
    }

    private Task ManejarExcepcion(HttpContext context, Exception exception)
    {
        HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError;
        context.Response.ContentType = "application/json";

        var resultado = string.Empty;

        switch (exception)
        {
            case BusinessRuleException exceptionReglaDeNegocio: httpStatusCode = HttpStatusCode.BadRequest;

            resultado = JsonSerializer.Serialize(exceptionReglaDeNegocio.Message);
            break;
            case NotFoundException: httpStatusCode = HttpStatusCode.NotFound;
            break;
        }

        context.Response.StatusCode = (int)httpStatusCode;
        return context.Response.WriteAsync(resultado);
    }
}

public static class ExceptionHandlerMiddlewareExtensions
{
    public static IApplicationBuilder UseManejadorExcepciones(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExceptionHandlerMiddleware>();
    }
}