using MathProject.Host.Application.Common.Interfaces;
using MathProject.Host.Application.DTO.Subject.CategoriesDtos;
using MathProject.Host.Domain.Aggregates.Subject.Categories;

namespace MathProject.Host.Application.Common.Mapping.Subject.Categories;

public class CustomDirectionOfTrainingMapperProfile : IMapperProfile
{
    /// <summary>
    /// Получение DTO направления обучения
    /// </summary>
    public DirectionOfTrainingDTO GetDirectionOfTrainingDto(DirectionOfTrainingEntity directionOfTraining)
    {
        if (directionOfTraining == null)
            throw new ArgumentNullException(nameof(directionOfTraining));

        return new DirectionOfTrainingDTO
        {
            Id = directionOfTraining.Id,
            Name = directionOfTraining.Name,
            Date = directionOfTraining.DateTrainingDir,
            DisplayOrder = int.Parse(directionOfTraining.DisplayOrder),
            IsVisible = directionOfTraining.IsVisible
        };
    }
    
    /// <summary>
    /// Получение списка DTO направлений обучения
    /// </summary>
    public async Task<List<DirectionOfTrainingDTO>> GetDirectionOfTrainingDtos(
        List<DirectionOfTrainingEntity> directionOfTrainings)
    {
        if (!directionOfTrainings.Any())
            throw new ArgumentNullException(nameof(directionOfTrainings));

        return directionOfTrainings.Select(GetDirectionOfTrainingDto).ToList();
    }
}