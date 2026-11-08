using YorFit.Domain.Exceptions;
using YorFit.Domain.ValuableObjects;

namespace YorFit.Domain.Entities;

public class User
{
    public Guid Id { get; private set; } = Guid.CreateVersion7();
    public Guid IdPersona { get; private set; }
    public Guid IdSede { get; private set; }
    public Guid IdRol { get; private set; }
    public string NombreUsuario { get; private set; } = default!;
    public Email Email { get; private set; } = default!;
    public string PasswordHash { get; private set; } = default!;
    public bool Estado { get; private set; } = true;
    public bool RequiereCambioPassword { get; private set; }

    public static User Crear(
        Guid idPersona,
        Guid idSede,
        Guid idRol,
        string nombreUsuario,
        Email email,
        string passwordHash,
        bool requiereCambioPassword)
    {
        ValidarId(idPersona, "La persona");
        ValidarId(idSede, "La sede");
        ValidarId(idRol, "El rol");
        ValidarNombreUsuario(nombreUsuario);
        ValidarEmail(email);
        ValidarPasswordHash(passwordHash);

        return new User
        {
            IdPersona = idPersona,
            IdSede = idSede,
            IdRol = idRol,
            NombreUsuario = nombreUsuario.Trim(),
            Email = email,
            PasswordHash = passwordHash,
            RequiereCambioPassword = requiereCambioPassword
        };
    }

    public void Actualizar(
        Guid idSede,
        Guid idRol,
        string nombreUsuario,
        Email email)
    {
        ValidarId(idSede, "La sede");
        ValidarId(idRol, "El rol");
        ValidarNombreUsuario(nombreUsuario);
        ValidarEmail(email);

        IdSede = idSede;
        IdRol = idRol;
        NombreUsuario = nombreUsuario.Trim();
        Email = email;
    }

    public void ActualizarPasswordHash(string passwordHash, bool requiereCambioPassword)
    {
        ValidarPasswordHash(passwordHash);
        PasswordHash = passwordHash;
        RequiereCambioPassword = requiereCambioPassword;
    }

    public void Activar() => Estado = true;
    public void Desactivar() => Estado = false;

    private static void ValidarId(Guid id, string campo)
    {
        if (id == Guid.Empty)
            throw new BusinessRuleException($"{campo} es requerida.");
    }

    private static void ValidarNombreUsuario(string nombreUsuario)
    {
        if (string.IsNullOrWhiteSpace(nombreUsuario))
            throw new BusinessRuleException("El nombre de usuario es obligatorio.");

        if (nombreUsuario.Trim().Length > 50)
            throw new BusinessRuleException("El nombre de usuario no puede exceder los 50 caracteres.");
    }

    private static void ValidarEmail(Email email)
    {
        if (email is null)
            throw new BusinessRuleException("El correo electrónico es obligatorio.");
    }

    private static void ValidarPasswordHash(string passwordHash)
    {
        if (string.IsNullOrWhiteSpace(passwordHash))
            throw new BusinessRuleException("El hash de la contraseña es obligatorio.");
    }
}
