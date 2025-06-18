using MathProject.Host.Application.Common.Interfaces;
using MathProject.Host.Application.DTO.Subject.CategoriesDtos;
using MathProject.Host.Domain.Aggregates.Subject.Categories;

namespace MathProject.Host.Application.Common.Mapping.Subject.Categories;

public class CustomTrainingCategoryMapperProfile : IMapperProfile
{
    /// <summary>
    /// Получение ДТО Категории Подготовки
    /// </summary>
    public TrainingCategoryDto GetTrainingCategoryDto(TrainingCategoryEntity trainingCategory)
    {
        if (trainingCategory == null)
        {
            throw new ArgumentNullException(nameof(trainingCategory));
        }

        return new TrainingCategoryDto
        {
            Id = trainingCategory.Id,
            SubjectId = trainingCategory.Subject.Id,
            Name = trainingCategory.Name,
            DisplayOrder = int.Parse(trainingCategory.DisplayOrder),
            IsVisible = trainingCategory.IsVisible
        };
    }

    /// <summary>
    /// Получение списка ДТО Категорий Подготовки
    /// </summary>
    public async Task<List<TrainingCategoryDto>> GetTrainingCategoryDtos(
        List<TrainingCategoryEntity> trainingCategories)
    {
        if (!trainingCategories.Any())
            throw new ArgumentNullException(nameof(trainingCategories));

        return trainingCategories.Select(GetTrainingCategoryDto).ToList();
    }
}