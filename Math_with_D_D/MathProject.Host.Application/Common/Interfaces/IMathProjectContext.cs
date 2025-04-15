using Microsoft.EntityFrameworkCore.Infrastructure;

namespace MathProject.Host.Application.Common.Interfaces;

public interface IMathProjectContext
{
    DatabaseFacade Database { get; }
    
    //TODO:Добавить DbSet после инфраструктуры
    
    void Migrate();
        
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}