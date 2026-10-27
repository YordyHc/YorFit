using System;
using System.Collections.Generic;
using System.Text;
using YorFit.Application.Utilities.Mediator;

namespace YorFit.Application.UseCases.Branchs.Commands.CreateBranch;

public record CreateBranchCommand
(
    string Nombre,
    string Codigo,
    string LineaDireccion1,
    string? LineaDireccion2,
    string Distrito,
    string Provincia,
    string? Referencia,
    string Pais,
    string CodigoPais,
    string NumeroNacional

): IRequest<Guid>;