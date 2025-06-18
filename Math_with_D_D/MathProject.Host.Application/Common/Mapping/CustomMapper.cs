using AutoMapper;
using MathProject.Host.Application.Common.Interfaces;
using MathProject.Host.Application.Common.Mapping.Subject;
using MathProject.Host.Application.Common.Mapping.Subject.Categories;

namespace MathProject.Host.Application.Common.Mapping;

public class CustomMapper : ICustomMapper
{
    private readonly CustomSubjectMapperProfile _subjectMapperProfile;
    private readonly CustomTrainingCategoryMapperProfile _trainingCategoryMapperProfile;
    private readonly CustomDirectionOfTrainingMapperProfile _directionOfTrainingMapperProfile;
    private readonly IMapper _autoMapper;

    public CustomMapper(IMapper autoMapper)
    {
        _autoMapper = autoMapper ?? throw new ArgumentNullException(nameof(autoMapper));
        _subjectMapperProfile = new CustomSubjectMapperProfile();
        _trainingCategoryMapperProfile = new CustomTrainingCategoryMapperProfile();
        _directionOfTrainingMapperProfile = new CustomDirectionOfTrainingMapperProfile();
    }
    
    public CustomSubjectMapperProfile SubjectMapperProfile => _subjectMapperProfile;
    public CustomTrainingCategoryMapperProfile TrainingCategoryMapperProfile => _trainingCategoryMapperProfile;
    public CustomDirectionOfTrainingMapperProfile DirectionOfTrainingMapperProfile => _directionOfTrainingMapperProfile;
    public IMapper AutoMapper => _autoMapper;
}