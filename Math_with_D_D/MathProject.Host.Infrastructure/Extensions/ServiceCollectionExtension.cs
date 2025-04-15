using MathProject.Host.Application.Application.Extensions;
using MathProject.Host.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MathProject.Host.Infrastructure.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddMathProjectCollectionInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        if (services == null)
            throw new ArgumentNullException(nameof(services));

        services.AddDbContext<MathProjectContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("PostgreSqlDatabase")));
            
        services.AddScoped<IMathProjectContext>(provider => provider.GetService<MathProjectContext>()
                                                            ?? throw new InvalidOperationException());
        //services.AddScoped<ICpuRepository, CpuRepository>();
            
        services.AddApplication();


        return services;
    }
}