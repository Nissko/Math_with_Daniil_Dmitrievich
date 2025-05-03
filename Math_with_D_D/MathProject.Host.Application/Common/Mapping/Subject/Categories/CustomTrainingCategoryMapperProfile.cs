using MathProject.Host.Application.Common.Interfaces;
using MathProject.Host.Application.DTO.Subject.Categories;
using MathProject.Host.Domain.Aggregates.Subject;

namespace MathProject.Host.Application.Common.Mapping.Subject.Categories;

public class CustomTrainingCategoryMapperProfile : IMapperProfile
{
    public TrainingCategoryDTO GetTrainingCategoryDto(TrainingCategoryEntity trainingCategory)
    {
        if (trainingCategory == null)
        {
            throw new ArgumentNullException(nameof(trainingCategory));
        }

        return new TrainingCategoryDTO
        {
            Id = trainingCategory.Id,
            SubjectId = trainingCategory.Subject.Id,
            SubjectName = trainingCategory.Subject.Name,
            Name = trainingCategory.Name,
            DisplayOrder = int.Parse(trainingCategory.DisplayOrder),
            IsVisible = trainingCategory.IsVisible
        };
    }

    public IEnumerable<TrainingCategoryDTO> GetTrainingCategoryDtos(
        IEnumerable<TrainingCategoryEntity> trainingCategories)
    {
        if (!trainingCategories.Any())
            throw new ArgumentNullException(nameof(trainingCategories));

        return trainingCategories.Select(GetTrainingCategoryDto).ToList();
    }
    
    //TODO:добавить DirectionOfTrainings в вывод маппера
}