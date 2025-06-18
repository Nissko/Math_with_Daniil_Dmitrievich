using MathProject.Host.Application.Common.Interfaces;
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
            Name = subject.Name
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
}