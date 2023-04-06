using Autofac;
using KOTIT.Employees.Application.Queries;
using KOTIT.Employees.Domain.Repositories;
using MediatR.Extensions.Autofac.DependencyInjection;
using MediatR.Extensions.Autofac.DependencyInjection.Builder;

namespace KOTIT.Employees.Application.Configurations;

public class DIConfigurations : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        var configuration = MediatRConfigurationBuilder.Create(typeof(GetEmployeesQuery).Assembly)
          .WithAllOpenGenericHandlerTypesRegistered()
          .Build();

        // MediatR
        builder.RegisterMediatR(configuration);

        // Generic Repositories

    }
}
