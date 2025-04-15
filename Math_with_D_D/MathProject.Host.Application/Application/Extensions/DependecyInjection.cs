using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace MathProject.Host.Application.Application.Extensions;

public static class DependecyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        if (services == null)
            throw new ArgumentNullException(nameof(services));
            
        // Регистрируем MediatR
        services.AddMediatR(Assembly.GetExecutingAssembly());
            
        // Регистрируем AutoMapper
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        // Регистрируем ICustomMapper
        //TODO:Сделать маппер
        //services.AddScoped<ICustomMapper, CustomMapper>();

        return services;
    }
}