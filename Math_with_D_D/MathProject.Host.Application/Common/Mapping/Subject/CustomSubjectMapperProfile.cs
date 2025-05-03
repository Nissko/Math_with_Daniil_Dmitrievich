using MathProject.Host.Application.Common.Interfaces;
using MathProject.Host.Application.DTO.Subject;
using MathProject.Host.Application.DTO.Subject.Categories;
using MathProject.Host.Domain.Aggregates.Subject;

namespace MathProject.Host.Application.Common.Mapping.Subject;

public class CustomSubjectMapperProfile : IMapperProfile
{
    public SubjectDTO GetSubjectDto(SubjectEntity subject)
    {
        if (subject == null)
            throw new ArgumentNullException(nameof(subject));

        return new SubjectDTO
        {
            Id = subject.Id,
            Name = subject.Name,
            TrainingCategories = subject.TrainingCategories
                .Select(MapTrainingCategory)
                .OrderBy(x => x.DisplayOrder)
                .ToList()
        };
    }
    
    public IEnumerable<SubjectDTO> GetSubjectDtos(IEnumerable<SubjectEntity> subjects)
    {
        if (subjects == null)
            throw new ArgumentNullException(nameof(subjects));

        return subjects.Select(GetSubjectDto).ToList();
    }

    private LightTrainingCategoryDTO MapTrainingCategory(TrainingCategoryEntity trainingCategory)
    {
        if (trainingCategory == null)
        {
            return new LightTrainingCategoryDTO();
        }

        return new LightTrainingCategoryDTO
        {
            Id = trainingCategory.Id,
            Name = trainingCategory.Name,
            DisplayOrder = int.Parse(trainingCategory.DisplayOrder),
            IsVisible = trainingCategory.IsVisible
        };
    }
}