using System.Net;
using System.Net.Http.Json;
using Testcontainers.PostgreSql;
using YorFit.Application.UseCases.Roles.Queries.GetRoleById;

namespace YorFit.Tests;

public class RolesPostgresApiTests
{
    // Comprueba que un rol creado por POST persiste y se recupera por GET en PostgreSQL.
    [Fact]
    public async Task Post_YGet_ConservaElRolEnPostgres()
    {
        await using var postgres = new PostgreSqlBuilder("postgres:16-alpine")
            .WithDatabase("yorfit_test")
            .WithUsername("postgres")
            .WithPassword("postgres")
            .Build();

        await postgres.StartAsync();

        await using var factory = new PostgresApiFactory(postgres.GetConnectionString());
        using var cliente = factory.CreateClient();

        await factory.ApplyMigrationsAsync();

        var respuestaCreacion = await cliente.PostAsJsonAsync("/api/roles", new
        {
            Nombre = "Entrenador",
            Descripcion = "Acceso al entrenamiento"
        });

        Assert.Equal(HttpStatusCode.Created, respuestaCreacion.StatusCode);

        var id = await respuestaCreacion.Content.ReadFromJsonAsync<Guid>();
        var respuestaLectura = await cliente.GetAsync($"/api/roles/{id}");

        Assert.Equal(HttpStatusCode.OK, respuestaLectura.StatusCode);

        var rol = await respuestaLectura.Content.ReadFromJsonAsync<RoleDetailDTO>();
        Assert.NotNull(rol);
        Assert.Equal(id, rol.Id);
        Assert.Equal("Entrenador", rol.Nombre);
        Assert.Equal("Acceso al entrenamiento", rol.Descripcion);
        Assert.True(rol.Estado);
    }
}