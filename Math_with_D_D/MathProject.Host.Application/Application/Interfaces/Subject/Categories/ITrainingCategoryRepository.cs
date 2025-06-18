using MathProject.Host.Application.Application.Templates.Request.Subject.Categories.DirectionOfTrainingRequests;
using MathProject.Host.Application.Application.Templates.Request.Subject.Categories.TrainingCategoryRequests;
using MathProject.Host.Application.DTO.Subject.CategoriesDtos;

namespace MathProject.Host.Application.Application.Interfaces.Subject.Categories;

public interface ITrainingCategoryRepository
{
    /// <summary>
    /// Получить категории всех предметов
    /// </summary>
    Task<IEnumerable<TrainingCategoryDto>> GetTrainingCategoriesAsync();
    
    /// <summary>
    /// Получение списка направлений обучения
    /// по id-категории подготовки
    /// </summary>
    Task<IEnumerable<DirectionOfTrainingDTO>> GetDirectionOfTrainingsFromTrainingCategoryId(Guid trainingCategoryId);
    
    /// <summary>
    /// Добавление новых направлений обучения
    /// </summary>
    Task<TrainingCategoryDto> AddTrainingCategoriesAsync(AddDirectionOfTrainingsRequest directionOfTrainings);
    
    /// <summary>
    /// Изменить категорию по ИД
    /// </summary>
    Task<TrainingCategoryDto> UpdateTrainingCategoryAsync(UpdateTrainingCategoryRequest updateTrainingCategory);

    /// <summary>
    /// Удалить категорию по ИД
    /// </summary>
    Task DeleteTrainingCategoryAsync(Guid trainingCategoryId);
    
    /// <summary>
    /// Вызов сохранения контекста
    /// </summary>
    Task SaveChangesAsync(CancellationToken cancellationToken);
}