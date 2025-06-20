using MathProject.Host.Application.Application.Extensions;
using MathProject.Host.Application.Application.Interfaces.Subject;
using MathProject.Host.Application.Application.Interfaces.Subject.Categories;
using MathProject.Host.Application.Common.Interfaces;
using MathProject.Host.Infrastructure.Repositories.Subject;
using MathProject.Host.Infrastructure.Repositories.Subject.Categories;
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
        //Репозитории
        services.AddScoped<ISubjectRepository, SubjectRepository>();
        services.AddScoped<ITrainingCategoryRepository, TrainingCategoriesRepository>();
        services.AddScoped<IDirectionOfTrainingRepository, DirectionOfTrainingRepository>();
            
        services.AddApplication();
        
        return services;
    }
}