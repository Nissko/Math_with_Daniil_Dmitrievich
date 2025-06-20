using MathProject.Host.Application.DTO.Subject.CategoriesDtos;

namespace MathProject.Host.Application.Application.Interfaces.Subject.Categories;

public interface IDirectionOfTrainingRepository
{
    /// <summary>
    /// Получение всех направлений обучения
    /// </summary>
    Task<IEnumerable<DirectionOfTrainingDTO>> GetDirectionOfTrainingsAsync();
    
    /// <summary>
    /// Получение направления обучения по id
    /// </summary>
    Task<DirectionOfTrainingDTO> GetDirectionOfTrainingsByIdAsync(Guid directionOfTrainingId);
    
    /// <summary>
    /// Получение всех тем обучения по directionOfTrainingId
    /// </summary>
    Task<IEnumerable<LearningTopicDTO>> GetLearningTopicsAsync(Guid directionOfTrainingId);
        
    /// <summary>
    /// Вызов сохранения контекста
    /// </summary>
    Task SaveChangesAsync(CancellationToken cancellationToken);
}