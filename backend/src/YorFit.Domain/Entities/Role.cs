using System;
using System.Collections.Generic;
using System.Text;
using YorFit.Domain.Exceptions;

namespace YorFit.Domain.Entities;

public class Role
{
    public Guid Id { get; private set; } = Guid.CreateVersion7();
    public string Nombre { get; private set; } = default!;
    public string Descripcion { get; private set; } = default!;
    public bool Estado { get; private set; } = true;

    public static Role Crear(string nombre, string descripcion)
    {
        ValidarNombre(nombre);
        ValidarDescripcion(descripcion);

        return new Role
        {
            Nombre = nombre.Trim(),
            Descripcion = descripcion.Trim()
        };
    }

    public void Actualizar(string nombre, string descripcion)
    {
        ValidarNombre(nombre);
        ValidarDescripcion(descripcion);

        Nombre = nombre.Trim();
        Descripcion = descripcion.Trim();
    }

    public void Activar() => Estado = true;
    public void Desactivar() => Estado = false;

    private static void ValidarNombre(string nombre)
    {
        if (string.IsNullOrWhiteSpace(nombre))
        {
            throw new BusinessRuleException("El nombre del rol es requerido.");
        }
        if(nombre.Trim().Length > 30)
        {
            throw new BusinessRuleException("El nombre del rol no puede exceder los 30 caracteres.");
        }
    }
    private static void ValidarDescripcion(string descripcion)
    {
        if (string.IsNullOrWhiteSpace(descripcion))
        {
            throw new BusinessRuleException("La descripción de la sede es requerido.");
        }
        if(descripcion.Trim().Length > 100)
        {
            throw new BusinessRuleException("El descripción de la sede no puede exceder los 100 caracteres.");
        }
    }
}