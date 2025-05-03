using MathProject.Host.Application.Common.Interfaces;
using MathProject.Host.Domain.Aggregates.Subject;
using MathProject.Host.Infrastructure.Configurations.Subject;
using MathProject.Host.Infrastructure.Configurations.Subject.Categories;
using Microsoft.EntityFrameworkCore;

namespace MathProject.Host.Infrastructure;

public sealed class MathProjectContext : DbContext, IMathProjectContext
{
    private readonly string _defaultSchema = "MATHPROJECT_MAIN";

    public MathProjectContext(DbContextOptions<MathProjectContext> options)
        : base(options)
    { }
    
    //TODO:Добавлять контексты
    public DbSet<SubjectEntity> Subject { get; set; }
    public DbSet<TrainingCategoryEntity> TrainingCategory { get; set; }
    public DbSet<DirectionOfTrainingEntity> DirectionOfTraining { get; set; }
    public DbSet<LearningTopicsEntity> LearningTopics { get; set; }
    public DbSet<SubthemesOfLearningEntity> SubthemesOfLearning { get; set; }

    public void Migrate()
    {
        Database.Migrate();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //TODO:Добавлять конфигурации
        modelBuilder.ApplyConfiguration(new SubjectConfiguration());
        modelBuilder.ApplyConfiguration(new TrainingCategoryConfiguration());
        modelBuilder.ApplyConfiguration(new DirectionOfTrainingConfiguration());
        modelBuilder.ApplyConfiguration(new LearningTopicsConfiguration());
        modelBuilder.ApplyConfiguration(new SubthemesOfLearningConfiguration());

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MathProjectContext).Assembly);
    }

    public MathProjectContext()
    {
        Database.EnsureCreated();
    }
        
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //Адрес тестового сервера
        optionsBuilder.UseNpgsql("Server=45.91.8.160;User Id=math_proj_admin;Password=sYf7hv;Port=5432;Database=math_project_db;")
            .UseLazyLoadingProxies();
    }

    private static DbContextOptions<T> ChangeOptionsType<T>(DbContextOptions options) where T : DbContext
    {
        return new DbContextOptionsBuilder<T>()
            .Options;
    }
}