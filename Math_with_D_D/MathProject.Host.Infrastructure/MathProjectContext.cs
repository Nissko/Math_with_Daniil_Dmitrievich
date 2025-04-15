using MathProject.Host.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MathProject.Host.Infrastructure;

public class MathProjectContext : DbContext, IMathProjectContext
{
    //TODO:Добавить название схемы БД
    protected readonly string _defaultSchema = "";

    public MathProjectContext(DbContextOptions<MathProjectContext> options)
        : base(options)
    { }
    
    //TODO:Добавить контексты
        
    public void Migrate()
    {
        Database.Migrate();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //TODO:Добавить конфигурации

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MathProjectContext).Assembly);
    }

    public MathProjectContext()
    {
        Database.EnsureCreated();
    }
        
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Server=localhost;User Id=postgres;Password=0000;Port=5432;Database=squarePcDB;")
            .UseLazyLoadingProxies();
    }
        
    protected static DbContextOptions<T> ChangeOptionsType<T>(DbContextOptions options) where T : DbContext
    {
        return new DbContextOptionsBuilder<T>()
            .Options;
    }
}