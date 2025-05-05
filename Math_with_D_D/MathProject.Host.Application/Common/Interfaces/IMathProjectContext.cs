using MathProject.Host.Domain.Aggregates.Subject;
using MathProject.Host.Domain.Aggregates.Subject.Categories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace MathProject.Host.Application.Common.Interfaces;

public interface IMathProjectContext
{
    DatabaseFacade Database { get; }
    
    public DbSet<SubjectEntity> Subject { get; set; }
    public DbSet<TrainingCategoryEntity> TrainingCategory { get; set; }
    public DbSet<DirectionOfTrainingEntity> DirectionOfTraining { get; set; }
    public DbSet<LearningTopicsEntity> LearningTopics { get; set; }
    public DbSet<SubthemesOfLearningEntity> SubthemesOfLearning { get; set; }
    
    void Migrate();
        
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}