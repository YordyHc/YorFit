using YorFit.Domain.Exceptions;

namespace YorFit.Domain.Entities;

public class Trainer
{
    public Guid Id { get; private set; } = Guid.CreateVersion7();
    public Guid IdEmpleado { get; private set; }
    public string Especialidad { get; private set; } = default!;
    public bool Estado { get; private set; } = true;

    public static Trainer Crear(Guid idEmpleado, string especialidad)
    {
        ValidarIdEmpleado(idEmpleado);
        ValidarEspecialidad(especialidad);

        return new Trainer
        {
            IdEmpleado = idEmpleado,
            Especialidad = especialidad.Trim()
        };
    }

    public void Actualizar(string especialidad)
    {
        ValidarEspecialidad(especialidad);
        Especialidad = especialidad.Trim();
    }

    public void Activar() => Estado = true;
    public void Desactivar() => Estado = false;

    private static void ValidarIdEmpleado(Guid idEmpleado)
    {
        if (idEmpleado == Guid.Empty)
            throw new BusinessRuleException("El empleado del entrenador es requerido.");
    }

    private static void ValidarEspecialidad(string especialidad)
    {
        if (string.IsNullOrWhiteSpace(especialidad))
            throw new BusinessRuleException("La especialidad del entrenador es obligatoria.");

        if (especialidad.Trim().Length > 100)
            throw new BusinessRuleException("La especialidad no puede exceder los 100 caracteres.");
    }
}
