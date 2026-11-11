using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using YorFit.Application.Utilities.Mediator;
//sede
using YorFit.Application.UseCases.Branchs.Commands.UpdateBranch;
using YorFit.Application.UseCases.Branchs.Commands.ChangeBranchStatus;
using YorFit.Application.UseCases.Branchs.Commands.CreateBranch;
using YorFit.Application.UseCases.Branchs.Queries.FilterBranchs;
using YorFit.Application.UseCases.Branchs.Queries.GetBranchById;
using YorFit.Application.UseCases.Branchs.Commands.DeleteBranch;
//rol
using YorFit.Application.UseCases.Roles.Commands.CreateRole;
using YorFit.Application.UseCases.Roles.Commands.UpdateRole;
using YorFit.Application.UseCases.Roles.Commands.ChangeRoleStatus;
using YorFit.Application.UseCases.Roles.Commands.DeleteRole;
using YorFit.Application.UseCases.Roles.Queries.GetRoleById;
using YorFit.Application.UseCases.Roles.Queries.FilterRoles;
using YorFit.Application.UseCases.Persons.Commands.CreatePerson;
using YorFit.Application.UseCases.Persons.Commands.UpdatePerson;
using YorFit.Application.UseCases.Persons.Commands.DeletePerson;
using YorFit.Application.UseCases.Users.Commands.CreateUser;
using YorFit.Application.UseCases.Users.Commands.UpdateUser;
using YorFit.Application.UseCases.Users.Commands.DeleteUser;
using YorFit.Application.UseCases.Users.Commands.ChangeUserPasswordHash;
using YorFit.Application.UseCases.Employees.Commands.CreateEmployee;
using YorFit.Application.UseCases.Employees.Commands.UpdateEmployee;
using YorFit.Application.UseCases.Employees.Commands.DeleteEmployee;
using YorFit.Application.UseCases.Members.Commands.CreateMember;
using YorFit.Application.UseCases.Members.Commands.UpdateMember;
using YorFit.Application.UseCases.Members.Commands.DeleteMember;
using YorFit.Application.UseCases.Trainers.Commands.CreateTrainer;
using YorFit.Application.UseCases.Trainers.Commands.UpdateTrainer;
using YorFit.Application.UseCases.Trainers.Commands.DeleteTrainer;

namespace YorFit.Application;

public static class DependencyInjection
{
    public static IServiceCollection AgregarAplicacion(this IServiceCollection services)
    {
        services.AddTransient<IMediator, SimpleMediator>();

        services.AddScoped<IRequestHandler<CreateBranchCommand, Guid>, CreateBranchUseCase>();

        services.AddScoped<IRequestHandler<UpdateBranchCommand>, UpdateBranchUseCase>();

        services.AddScoped<IRequestHandler<ChangeBranchStatusCommand>, ChangeBranchStatusUseCase>();
        
        services.AddScoped<IRequestHandler<QueryGetBranchById, BranchDetailDTO>, UseCaseGetBranchById>();

        services.AddScoped<IRequestHandler<FilterBranchsQuery, List<FilteredBranchDTO>>, FilterBranchsUseCase>();

        services.AddScoped<IRequestHandler<DeleteBranchCommand>, DeleteBranchUseCase>();

        //rol

        services.AddScoped<IRequestHandler<CreateRoleCommand, Guid>, CreateRoleUseCase>();

        services.AddScoped<IRequestHandler<UpdateRoleCommand>, UpdateRoleUseCase>();

        services.AddScoped<IRequestHandler<ChangeRoleStatusCommand>, ChangeRoleStatusUseCase>();
        
        services.AddScoped<IRequestHandler<QueryGetRoleById, RoleDetailDTO>, UseCaseGetRoleById>();

        services.AddScoped<IRequestHandler<FilterRolesQuery, List<FilteredRoleDTO>>, FilterRolesUseCase>();

        services.AddScoped<IRequestHandler<DeleteRoleCommand>, DeleteRoleUseCase>();

        // Personas
        services.AddScoped<IRequestHandler<CreatePersonCommand, Guid>, CreatePersonUseCase>();
        services.AddScoped<IRequestHandler<UpdatePersonCommand>, UpdatePersonUseCase>();
        services.AddScoped<IRequestHandler<DeletePersonCommand>, DeletePersonUseCase>();

        // Usuarios
        services.AddScoped<IRequestHandler<CreateUserCommand, Guid>, CreateUserUseCase>();
        services.AddScoped<IRequestHandler<UpdateUserCommand>, UpdateUserUseCase>();
        services.AddScoped<IRequestHandler<DeleteUserCommand>, DeleteUserUseCase>();
        services.AddScoped<IRequestHandler<ChangeUserPasswordHashCommand>, ChangeUserPasswordHashUseCase>();

        // Empleados
        services.AddScoped<IRequestHandler<CreateEmployeeCommand, Guid>, CreateEmployeeUseCase>();
        services.AddScoped<IRequestHandler<UpdateEmployeeCommand>, UpdateEmployeeUseCase>();
        services.AddScoped<IRequestHandler<DeleteEmployeeCommand>, DeleteEmployeeUseCase>();

        // Socios
        services.AddScoped<IRequestHandler<CreateMemberCommand, Guid>, CreateMemberUseCase>();
        services.AddScoped<IRequestHandler<UpdateMemberCommand>, UpdateMemberUseCase>();
        services.AddScoped<IRequestHandler<DeleteMemberCommand>, DeleteMemberUseCase>();

        // Entrenadores
        services.AddScoped<IRequestHandler<CreateTrainerCommand, Guid>, CreateTrainerUseCase>();
        services.AddScoped<IRequestHandler<UpdateTrainerCommand>, UpdateTrainerUseCase>();
        services.AddScoped<IRequestHandler<DeleteTrainerCommand>, DeleteTrainerUseCase>();

        return services;
    }
}