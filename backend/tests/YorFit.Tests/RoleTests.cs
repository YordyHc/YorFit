using Xunit;
using YorFit.Domain.Entities;
using YorFit.Domain.Exceptions;
using Moq;
using YorFit.Application.Contracts;
using YorFit.Application.UseCases.Roles.Commands.CreateRole;

namespace YorFit.Tests;

public class RoleTests
{
    // Comprueba que un rol valido recorta espacios y queda activo por defecto.
    [Fact]
    public void Crear_ConDatosValidos_RecortaEspaciosYActivaElRol()
    {
        var rol = Role.Crear("  Administrador  ", "  Acceso completo  ");

        Assert.Equal("Administrador", rol.Nombre);
        Assert.Equal("Acceso completo", rol.Descripcion);
        Assert.True(rol.Estado);
    }

    // Comprueba que un nombre vacio incumple una regla de dominio.
    [Fact]
    public void Crear_ConNombreVacio_LanzaExcepcion()
    {
        Assert.Throws<BusinessRuleException>(
            () => Role.Crear(" ", "Acceso completo"));
    }

    // Comprueba que un rol nuevo se guarda y se devuelve su identificador.
    [Fact]
    public async Task Handle_CuandoElNombreNoExiste_GuardaElRolYDevuelveSuId()
    {
        var repositorio = new Mock<IRoleRepository>();
        repositorio
            .Setup(r => r.Existe("Entrenador"))
            .ReturnsAsync(false);

        Role? rolGuardado = null;

        repositorio
            .Setup(r => r.Agregar(It.IsAny<Role>()))
            .Callback<Role>(rol => rolGuardado = rol)
            .Returns(Task.CompletedTask);

        var casoDeUso = new CreateRoleUseCase(repositorio.Object);
        var comando = new CreateRoleCommand(" Entrenador ", " Acceso al entrenamiento ");

        var id = await casoDeUso.Handle(comando);

        Assert.NotNull(rolGuardado);
        Assert.Equal("Entrenador", rolGuardado.Nombre);
        Assert.Equal(id, rolGuardado.Id);
        repositorio.Verify(r => r.Agregar(It.IsAny<Role>()), Times.Once);
    }

    // Comprueba que un nombre duplicado provoca un error y no se guarda.
    [Fact]
    public async Task Handle_CuandoElNombreYaExiste_LanzaExcepcionYSinGuardar()
    {
        var repositorio = new Mock<IRoleRepository>();
        repositorio
            .Setup(r => r.Existe("Entrenador"))
            .ReturnsAsync(true);

        var casoDeUso = new CreateRoleUseCase(repositorio.Object);
        var comando = new CreateRoleCommand("Entrenador", "Acceso al entrenamiento");

        await Assert.ThrowsAsync<BusinessRuleException>(
            () => casoDeUso.Handle(comando));

        repositorio.Verify(r => r.Existe("Entrenador"), Times.Once);
        repositorio.Verify(r => r.Agregar(It.IsAny<Role>()), Times.Never);
    }

    // Comprueba cuatro casos de nombre o descripcion vacios sin consultar ni guardar.
    [Theory]
    [InlineData("", "Acceso completo")]
    [InlineData(" ", "Acceso completo")]
    [InlineData("Entrenador", "")]
    [InlineData("Entrenador", " ")]
    public async Task Handle_CuandoNombreODescripcionEstaVacio_LanzaExcepcionSinConsultarRepositorio(
        string nombre,
        string descripcion)
    {
        var repositorio = new Mock<IRoleRepository>();
        var casoDeUso = new CreateRoleUseCase(repositorio.Object);
        var comando = new CreateRoleCommand(nombre, descripcion);

        await Assert.ThrowsAsync<BusinessRuleException>(
            () => casoDeUso.Handle(comando));

        repositorio.Verify(r => r.Existe(It.IsAny<string>()), Times.Never);
        repositorio.Verify(r => r.Agregar(It.IsAny<Role>()), Times.Never);
    }
}