using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Moq;
using YorFit.Application.Contracts;
using YorFit.Domain.Entities;

namespace YorFit.Tests;

public class YorFitApiFactory : WebApplicationFactory<Program>
{
    public Mock<IRoleRepository> RepositorioRoles { get; } = new();

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        RepositorioRoles
            .Setup(r => r.Existe(It.IsAny<string>()))
            .ReturnsAsync(false);

        RepositorioRoles
            .Setup(r => r.Agregar(It.IsAny<Role>()))
            .Returns(Task.CompletedTask);

        builder.ConfigureTestServices(services =>
        {
            services.RemoveAll<IRoleRepository>();
            services.AddSingleton(RepositorioRoles.Object);
        });
    }
}