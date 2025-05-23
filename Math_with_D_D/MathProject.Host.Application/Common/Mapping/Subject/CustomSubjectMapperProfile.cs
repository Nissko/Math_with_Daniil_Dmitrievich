﻿using MathProject.Host.Application.Common.Interfaces;
using MathProject.Host.Application.DTO.Subject;
using MathProject.Host.Application.DTO.Subject.Lights;
using MathProject.Host.Domain.Aggregates.Subject;
using MathProject.Host.Domain.Aggregates.Subject.Categories;

namespace MathProject.Host.Application.Common.Mapping.Subject;

public class CustomSubjectMapperProfile : IMapperProfile
{
    /// <summary>
    /// Получение ДТО предметов
    /// </summary>
    public SubjectDto GetSubjectDto(SubjectEntity subject)
    {
        if (subject == null)
            throw new ArgumentNullException(nameof(subject));

        return new SubjectDto
        {
            Id = subject.Id,
            Name = subject.Name,
            TrainingCategories = subject.TrainingCategories
                .Select(MapTrainingCategory)
                .OrderBy(x => x.DisplayOrder)
                .ToList()
        };
    }
    
    /// <summary>
    /// Получение списка ДТО предметов
    /// </summary>
    public IEnumerable<SubjectDto> GetSubjectDtos(IEnumerable<SubjectEntity> subjects)
    {
        if (subjects == null)
            throw new ArgumentNullException(nameof(subjects));

        return subjects.Select(GetSubjectDto).ToList();
    }

    /// <summary>
    /// Вывод облегченного TrainingCategory в ДТО предметов
    /// </summary>
    private LightTrainingCategoryDto MapTrainingCategory(TrainingCategoryEntity trainingCategory)
    {
        if (trainingCategory == null)
        {
            return new LightTrainingCategoryDto();
        }

        return new LightTrainingCategoryDto
        {
            Id = trainingCategory.Id,
            Name = trainingCategory.Name,
            DisplayOrder = int.Parse(trainingCategory.DisplayOrder),
            IsVisible = trainingCategory.IsVisible
        };
    }
}