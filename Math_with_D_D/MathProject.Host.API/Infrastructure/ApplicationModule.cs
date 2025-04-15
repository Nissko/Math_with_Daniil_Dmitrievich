using Autofac;

namespace MathProject.Host.API.Infrastructure;

public class ApplicationModule : Autofac.Module
{
    public ApplicationModule()
    {
    }

    protected override void Load(ContainerBuilder builder)
    {
        /*builder.RegisterAssemblyTypes(typeof(ChangeBookEventHandler).GetTypeInfo().Assembly)
            .AsClosedTypesOf(typeof(IIntegrationEventHandler<>));
        builder.RegisterAssemblyTypes(typeof(RefundBookEventHandler).GetTypeInfo().Assembly)
            .AsClosedTypesOf(typeof(IIntegrationEventHandler<>));*/
    }
}