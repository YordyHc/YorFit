using System.Net;
using System.Net.Http.Json;
using Moq;
using YorFit.Domain.Entities;

namespace YorFit.Tests;

public class RolesApiTests
{
    // Comprueba que la API responde 201 y solicita guardar un rol valido.
    [Fact]
    public async Task Post_ConRolValido_RespondeCreatedYGuardaElRol()
    {
        await using var factory = new YorFitApiFactory();
        using var cliente = factory.CreateClient();

        var respuesta = await cliente.PostAsJsonAsync("/api/roles", new
        {
            Nombre = "Entrenador",
            Descripcion = "Acceso al entrenamiento"
        });

        Assert.Equal(HttpStatusCode.Created, respuesta.StatusCode);

        var id = await respuesta.Content.ReadFromJsonAsync<Guid>();
        Assert.NotEqual(Guid.Empty, id);
        Assert.NotNull(respuesta.Headers.Location);

        factory.RepositorioRoles.Verify(
            r => r.Agregar(It.Is<Role>(rol => rol.Nombre == "Entrenador")),
            Times.Once);
    }

    // Comprueba que un rol duplicado responde 400 y no se guarda.
    [Fact]
    public async Task Post_CuandoElRolYaExiste_RespondeBadRequestYSinGuardar()
    {
        await using var factory = new YorFitApiFactory();
        using var cliente = factory.CreateClient();

        factory.RepositorioRoles
            .Setup(r => r.Existe("Entrenador"))
            .ReturnsAsync(true);

        var respuesta = await cliente.PostAsJsonAsync("/api/roles", new
        {
            Nombre = "Entrenador",
            Descripcion = "Acceso al entrenamiento"
        });

        Assert.Equal(HttpStatusCode.BadRequest, respuesta.StatusCode);

        var mensaje = await respuesta.Content.ReadFromJsonAsync<string>();
        Assert.Equal("Ya existe un rol con el nombre: Entrenador", mensaje);

        factory.RepositorioRoles.Verify(
            r => r.Agregar(It.IsAny<Role>()),
            Times.Never);
    }
}