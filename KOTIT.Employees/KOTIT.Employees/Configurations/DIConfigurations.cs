using Autofac;
using KOTIT.Employees.Application.Queries;
using KOTIT.Employees.Domain.Repositories;
using KOTIT.Employees.Infrastructure.Repositories;
using MediatR.Extensions.Autofac.DependencyInjection;
using MediatR.Extensions.Autofac.DependencyInjection.Builder;

namespace KOTIT.Employees.Infrastructure.Host.Configurations;

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
        builder
            .RegisterGeneric(typeof(Repository<>))
            .As(typeof(IRepository<>))
            .InstancePerLifetimeScope();
    }
}
