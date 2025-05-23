﻿using MathProject.Host.Application.Application.Templates.Request.Subject;
using MathProject.Host.Application.Application.Templates.Request.Subject.Categories.TrainingCategoryRequests;
using MathProject.Host.Application.DTO.Subject;
using MathProject.Host.Domain.Aggregates.Subject;

namespace MathProject.Host.Application.Application.Interfaces.Subject;

public interface ISubjectRepository
{
    /// <summary>
    /// Получение списка предметов
    /// </summary>
    Task<IEnumerable<SubjectDto>> GetSubjectsAsync();
    
    /// <summary>
    /// Получение определенного предмета
    /// </summary>
    Task<SubjectDto> GetSubjectByIdAsync(Guid subjectId);
    
    /// <summary>
    /// Добавление нового предмета
    /// </summary>
    Task<SubjectDto> CreateSubjectAsync(CreateSubjectRequest subjectRequest);
    
    /// <summary>
    /// Добавление новых категорий подготовки
    /// </summary>
    Task<SubjectDto> AddTrainingCategoriesAsync(AddTrainingCategoriesRequest trainingCategories);
    
    /// <summary>
    /// Изменение существующего предмета
    /// </summary>
    Task<SubjectEntity> UpdateSubjectAsync(UpdateSubjectRequest updateSubjectRequest);
    
    /// <summary>
    /// Удаление предмета
    /// </summary>
    Task  DeleteSubjectAsync(Guid subjectId);
    
    /// <summary>
    /// Вызов сохранения контекста
    /// </summary>
    Task SaveChangesAsync(CancellationToken cancellationToken);
}