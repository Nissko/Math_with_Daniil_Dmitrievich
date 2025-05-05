using MathProject.Host.Application.Common.Interfaces;
using MathProject.Host.Application.DTO.Subject.CategoriesDtos;
using MathProject.Host.Application.DTO.Subject.Lights;
using MathProject.Host.Domain.Aggregates.Subject.Categories;

namespace MathProject.Host.Application.Common.Mapping.Subject.Categories;

public class CustomTrainingCategoryMapperProfile : IMapperProfile
{
    /// <summary>
    /// Получение ДТО TrainingCategory
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
            SubjectName = trainingCategory.Subject.Name,
            Name = trainingCategory.Name,
            DisplayOrder = int.Parse(trainingCategory.DisplayOrder),
            IsVisible = trainingCategory.IsVisible,
            DirectionOfTrainings = trainingCategory.DirectionOfTrainings
                .Select(MapDirectionOfTraining)
                .OrderBy(x => x.DisplayOrder)
                .ToList()
        };
    }
    
    /// <summary>
    /// Получение облегченного ДТО TrainingCategory
    /// </summary>
    public LightTrainingCategoryDto GetLightTrainingCategoryDto(TrainingCategoryEntity trainingCategory)
    {
        if (trainingCategory == null)
        {
            throw new ArgumentNullException(nameof(trainingCategory));
        }

        return new LightTrainingCategoryDto
        {
            Id = trainingCategory.Id,
            Name = trainingCategory.Name,
            DisplayOrder = int.Parse(trainingCategory.DisplayOrder),
            IsVisible = trainingCategory.IsVisible,
            DirectionOfTrainings = trainingCategory.DirectionOfTrainings
                .Select(MapDirectionOfTraining)
                .OrderBy(x => x.DisplayOrder)
                .ToList()
        };
    }

    /// <summary>
    /// Получение списка ДТО TrainingCategory
    /// </summary>
    public IEnumerable<TrainingCategoryDto> GetTrainingCategoryDtos(
        IEnumerable<TrainingCategoryEntity> trainingCategories)
    {
        if (!trainingCategories.Any())
            throw new ArgumentNullException(nameof(trainingCategories));

        return trainingCategories.Select(GetTrainingCategoryDto).ToList();
    }
    
    /// <summary>
    /// Получение облегченного списка ДТО TrainingCategory
    /// </summary>
    public IEnumerable<LightTrainingCategoryDto> GetLightTrainingCategoryDtos(
        IEnumerable<TrainingCategoryEntity> trainingCategories)
    {
        if (!trainingCategories.Any())
            throw new ArgumentNullException(nameof(trainingCategories));

        return trainingCategories.Select(GetLightTrainingCategoryDto).ToList();
    }
    
    //TODO:добавить DirectionOfTrainings в вывод маппера
    private LightDirectionOfTrainingDTO MapDirectionOfTraining(DirectionOfTrainingEntity directionOfTraining)
    {
        if (directionOfTraining == null)
        {
            return new LightDirectionOfTrainingDTO();
        }

        return new LightDirectionOfTrainingDTO
        {
            Id = directionOfTraining.Id,
            Name = directionOfTraining.Name,
            Date = directionOfTraining.DateTrainingDir,
            DisplayOrder = int.Parse(directionOfTraining.DisplayOrder),
            IsVisible = directionOfTraining.IsVisible
        };
    }
}