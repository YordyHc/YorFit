using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using YorFit.Domain.Entities;

namespace YorFit.Infrastructure.Persistence;

internal class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    protected ApplicationDbContext()
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }

    public DbSet<Branch> Branchs { get; set; }

    public DbSet<Role> Roles { get; set; }

    public DbSet<Person> Persons { get; set; }

    public DbSet<User> Users { get; set; }

    public DbSet<Employee> Employees { get; set; }

    public DbSet<Member> Members { get; set; }

    public DbSet<Trainer> Trainers { get; set; }
}