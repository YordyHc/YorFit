using System;
using System.Collections.Generic;
using System.Text;

namespace YorFit.Application.UseCases.Branchs.Queries.GetProductById;

public record BranchDetailDTO(Guid Id, string Nombre, string Codigo,  string LineaDireccion1,  string? LineaDireccion2, string Distrito, string Provincia, string? Referencia, string Pais, string CodigoPais, string NumeroNacional, bool Activo);