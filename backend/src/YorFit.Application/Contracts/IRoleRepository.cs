using System;
using System.Collections.Generic;
using System.Text;
using YorFit.Domain.Entities;

namespace YorFit.Application.Contracts;

public interface IRoleRepository
{
    Task Agregar(Role rol);
    Task<bool> Existe(string nombre);
    Task<Role?> ObtenerPorId(Guid id);
    Task Actualizar(Role rol);
    // Task<List<Role>> ObtenerFiltrado(string? nombre, string? codigo, bool? activo);
    // Task Eliminar(Role rol);
}