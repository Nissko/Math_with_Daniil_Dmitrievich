using MathProject.Host.Application.Common.Interfaces;
using MathProject.Host.Application.DTO.Subject.CategoriesDtos;
using MathProject.Host.Domain.Aggregates.Subject.Categories;

namespace MathProject.Host.Application.Common.Mapping.Subject.Categories;

public class CustomSubthemeOfLearningMapperProfile : IMapperProfile
{
    /// <summary>
    /// Получение DTO подтемы обучения
    /// </summary>
    public SubthemeOfLearningsDTO GetSubthemeOfLearningDto(SubthemesOfLearningEntity learningTopics)
    {
        if (learningTopics == null)
            throw new ArgumentNullException(nameof(learningTopics));

        return new SubthemeOfLearningsDTO
        {
            Id = learningTopics.Id,
            LearningTopicId = learningTopics.LearningTopicsEntity.Id,
            Name = learningTopics.Name,
            DisplayOrder = int.Parse(learningTopics.DisplayOrder),
            IsVisible = learningTopics.IsVisible
        };
    }

    public async Task<List<SubthemeOfLearningsDTO>> GetSubthemeOfLearningsDto(
        List<SubthemesOfLearningEntity> learningTopics)
    {
        if (!learningTopics.Any())
            throw new ArgumentNullException(nameof(learningTopics));

        return learningTopics.Select(GetSubthemeOfLearningDto).ToList();
    }
}