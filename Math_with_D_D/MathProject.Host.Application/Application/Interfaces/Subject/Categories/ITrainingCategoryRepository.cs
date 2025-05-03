using MathProject.Host.Application.Application.Templates.Request.Subject.Categories.TrainingCategoryRequests;
using MathProject.Host.Application.DTO.Subject.Categories;

namespace MathProject.Host.Application.Application.Interfaces.Subject.Categories;

public interface ITrainingCategoryRepository
{
    /// <summary>
    /// Получить категории всех предметов
    /// </summary>
    Task<IEnumerable<TrainingCategoryDTO>> GetTrainingCategoriesAsync();
    
    /// <summary>
    /// Получить все категории предметов по ид предмета
    /// </summary>
    Task<IEnumerable<TrainingCategoryDTO>> GetTrainingCategoriesFromSubjectIdAsync(Guid subjectId);
    
    /// <summary>
    /// Изменить категорию по ИД
    /// </summary>
    Task<TrainingCategoryDTO> UpdateTrainingCategoryAsync(UpdateTrainingCategoryRequest updateTrainingCategory);

    /// <summary>
    /// Удалить категорию по ИД
    /// </summary>
    Task DeleteTrainingCategoryAsync(Guid trainingCategoryId);
    
    /// <summary>
    /// Вызов сохранения контекста
    /// </summary>
    Task SaveChangesAsync(CancellationToken cancellationToken);
}