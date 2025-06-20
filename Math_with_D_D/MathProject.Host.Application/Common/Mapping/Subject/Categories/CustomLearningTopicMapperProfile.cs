using MathProject.Host.Application.Common.Interfaces;
using MathProject.Host.Application.DTO.Subject.CategoriesDtos;
using MathProject.Host.Domain.Aggregates.Subject.Categories;

namespace MathProject.Host.Application.Common.Mapping.Subject.Categories;

public class CustomLearningTopicMapperProfile : IMapperProfile
{
    /// <summary>
    /// Получение DTO темы обучения
    /// </summary>
    public LearningTopicDTO GetLearningTopicDto(LearningTopicsEntity learningTopics)
    {
        if (learningTopics == null)
            throw new ArgumentNullException(nameof(learningTopics));

        return new LearningTopicDTO
        {
            Id = learningTopics.Id,
            DirectionOfTrainingId = learningTopics.DirectionOfTraining.Id,
            Name = learningTopics.Name,
            DisplayOrder = int.Parse(learningTopics.DisplayOrder),
            IsVisible = learningTopics.IsVisible
        };
    }

    public async Task<List<LearningTopicDTO>> GetLearningTopicsDto(List<LearningTopicsEntity> learningTopics)
    {
        if (!learningTopics.Any())
            throw new ArgumentNullException(nameof(learningTopics));

        return learningTopics.Select(GetLearningTopicDto).ToList();
    }
}