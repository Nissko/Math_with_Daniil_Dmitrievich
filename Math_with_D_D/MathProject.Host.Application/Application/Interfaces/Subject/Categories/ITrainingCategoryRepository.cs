﻿using MathProject.Host.Application.Application.Templates.Request.Subject.Categories.DirectionOfTrainingRequests;
using MathProject.Host.Application.Application.Templates.Request.Subject.Categories.TrainingCategoryRequests;
using MathProject.Host.Application.DTO.Subject.CategoriesDtos;
using MathProject.Host.Application.DTO.Subject.Lights;

namespace MathProject.Host.Application.Application.Interfaces.Subject.Categories;

public interface ITrainingCategoryRepository
{
    /// <summary>
    /// Получить категории всех предметов
    /// </summary>
    Task<IEnumerable<TrainingCategoryDto>> GetTrainingCategoriesAsync();
    
    /// <summary>
    /// Получить все категории предметов по ид предмета
    /// </summary>
    Task<IEnumerable<LightTrainingCategoryDto>> GetTrainingCategoriesFromSubjectIdAsync(Guid subjectId);
    
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