using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using YorFit.Application.Contracts;
using YorFit.Infrastructure.Persistence;
using YorFit.Infrastructure.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace YorFit.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AgregaInfraestructura(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(Options => Options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IBranchRepository, BranchRepository>();

        return services;
    }
}