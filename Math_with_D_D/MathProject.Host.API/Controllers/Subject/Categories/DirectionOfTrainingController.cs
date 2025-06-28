using System.Net.Mime;
using MathProject.Host.Application.Application.Interfaces.Subject.Categories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MathProject.Host.API.Controllers.Subject.Categories;

[ApiController]
[Route("[controller]")]
public class DirectionOfTrainingController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IDirectionOfTrainingRepository _directionOfTrainingRepository;

    /// <summary>
    /// Направление обучения
    /// </summary>
    public DirectionOfTrainingController(IMediator mediator,
        IDirectionOfTrainingRepository directionOfTrainingRepository)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        _directionOfTrainingRepository = directionOfTrainingRepository ??
                                         throw new ArgumentNullException(nameof(directionOfTrainingRepository));
    }
    
    /// <summary>
    /// Получение всех направлений обучения
    /// </summary>
    [HttpGet("")]
    [Consumes(MediaTypeNames.Application.Json)]
    public async Task<IActionResult> GetDirectionOfTrainings()
    {
        var result = await _directionOfTrainingRepository.GetDirectionOfTrainingsAsync();

        return Ok(result.OrderBy(dt => dt.DisplayOrder));
    }
    
    /// <summary>
    /// Получение направления обучения по id
    /// </summary>
    [HttpGet("{directionOfTrainingId}")]
    [Consumes(MediaTypeNames.Application.Json)]
    public async Task<IActionResult> GetDirectionOfTrainingById(Guid directionOfTrainingId)
    {
        var result = await _directionOfTrainingRepository
            .GetDirectionOfTrainingsByIdAsync(directionOfTrainingId);

        return Ok(result);
    }

    /// <summary>
    /// Получение направлений обучения по id предмета
    /// </summary>
    [HttpGet("get-direction-of-training-from-subject-id/{subjectId}")]
    [Consumes(MediaTypeNames.Application.Json)]
    public async Task<IActionResult> GetDirectionOfTrainingsBySubjectId(Guid subjectId)
    {
        var result = await _directionOfTrainingRepository
            .GetDirectionOfTrainingsBySubjectIdAsync(subjectId);

        return Ok(result);
    }
    
    /// <summary>
    /// Получение всех тем обучения по directionOfTrainingId
    /// </summary>
    [HttpGet("get-learning-topics/{directionOfTrainingId}")]
    [Consumes(MediaTypeNames.Application.Json)]
    public async Task<IActionResult> GetAllLearningTopics(Guid directionOfTrainingId)
    {
        var result = await _directionOfTrainingRepository
            .GetLearningTopicsAsync(directionOfTrainingId);

        return Ok(result.OrderBy(t => t.DisplayOrder));
    }
}