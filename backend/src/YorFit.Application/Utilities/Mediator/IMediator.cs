using System;
using System.Collections.Generic;
using System.Text;

namespace YorFit.Application.Utilities.Mediator;

public interface IMediator
{
    Task<TResponse> Send<TResponse>(IRequest<TResponse> request);
    Task Send(IRequest request);
}