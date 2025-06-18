using AutoMapper;
using MathProject.Host.Application.Common.Mapping.Subject;
using MathProject.Host.Application.Common.Mapping.Subject.Categories;

namespace MathProject.Host.Application.Common.Interfaces;

public interface ICustomMapper
{
    CustomTrainingCategoryMapperProfile TrainingCategoryMapperProfile { get; }
    CustomSubjectMapperProfile SubjectMapperProfile { get; }
    CustomDirectionOfTrainingMapperProfile DirectionOfTrainingMapperProfile { get; }
    IMapper AutoMapper { get; }
}