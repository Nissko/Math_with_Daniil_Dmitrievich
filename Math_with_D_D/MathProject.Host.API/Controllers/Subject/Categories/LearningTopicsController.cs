using System.Net.Mime;
using MathProject.Host.Application.Application.Interfaces.Subject.Categories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MathProject.Host.API.Controllers.Subject.Categories;

[ApiController]
[Route("[controller]")]
public class LearningTopicsController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILearningTopicsRepository _learningTopicsRepository;

    public LearningTopicsController(IMediator mediator, ILearningTopicsRepository learningTopicsRepository)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        _learningTopicsRepository = learningTopicsRepository ??
                                    throw new ArgumentNullException(nameof(learningTopicsRepository));
    }
    
    /// <summary>
    /// Получение всех тем обучений
    /// </summary>
    [HttpGet("")]
    [Consumes(MediaTypeNames.Application.Json)]
    public async Task<IActionResult> GetLearningTopics()
    {
        var result = await _learningTopicsRepository.GetLearningTopicsAsync();

        return Ok(result.OrderBy(x => x.DisplayOrder).GroupBy(x => x.DirectionOfTrainingId));
    }

    /// <summary>
    /// Получение всех подтем обучений по ид темы обучения
    /// </summary>
    [HttpGet("get-subtheme-of-learnings/{learningTopicId}")]
    [Consumes(MediaTypeNames.Application.Json)]
    public async Task<IActionResult> GetSubthemeOfLearningsByLearningTopicId(Guid learningTopicId)
    {
        var result = await _learningTopicsRepository.GetSubthemeOfLearningsAsync(learningTopicId);

        return Ok(result);
    }
}