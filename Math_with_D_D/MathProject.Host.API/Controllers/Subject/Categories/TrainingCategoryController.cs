using System.Net.Mime;
using MathProject.Host.Application.Application.Interfaces.Subject.Categories;
using MathProject.Host.Application.Application.Templates.Request.Subject.Categories.DirectionOfTrainingRequests;
using MathProject.Host.Application.Application.Templates.Request.Subject.Categories.TrainingCategoryRequests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MathProject.Host.API.Controllers.Subject.Categories;

[ApiController]
[Route("api/[controller]")]
public class TrainingCategoryController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ITrainingCategoryRepository _trainingCategoryRepository;
    
    public TrainingCategoryController(IMediator mediator, ITrainingCategoryRepository trainingCategoryRepository)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        _trainingCategoryRepository = trainingCategoryRepository ??
                                      throw new ArgumentNullException(nameof(trainingCategoryRepository));
    }

    /// <summary>
    /// Получение категорий всех предметов
    /// </summary>
    [HttpGet("")]
    [Consumes(MediaTypeNames.Application.Json)]
    public async Task<IActionResult> GetAllTrainingCategoriesAsync()
    {
        var result = await _trainingCategoryRepository.GetTrainingCategoriesAsync();

        return Ok(result.OrderBy(t => t.DisplayOrder).GroupBy(t => t.SubjectName));
    }
    
    /// <summary>
    /// Получить все категории предметов по ид предмета
    /// </summary>
    [HttpGet("{subjectId}")]
    [Consumes(MediaTypeNames.Application.Json)]
    public async Task<IActionResult> GetAllTrainingCategoriesFromSubjectIdAsync(Guid subjectId)
    {
        var result = await _trainingCategoryRepository.GetTrainingCategoriesFromSubjectIdAsync(subjectId);

        return Ok(result.OrderBy(t => t.DisplayOrder));
    }
    
    /// <summary>
    /// Добавление новых направлений обучения
    /// </summary>
    [HttpPost("add/direction-of-trainings")]
    [Consumes(MediaTypeNames.Application.Json)]
    public async Task<IActionResult> AddDirectionOfTrainings([FromBody] AddDirectionOfTrainingsRequest addDirectionOfTrainings)
    {
        var result = await _trainingCategoryRepository.AddTrainingCategoriesAsync(addDirectionOfTrainings);
        
        return Ok(result);
    }

    /// <summary>
    /// Изменение категории подготовки
    /// </summary>
    [HttpPost("change-training-category")]
    [Consumes(MediaTypeNames.Application.Json)]
    public async Task<IActionResult> ChangeTrainingCategory([FromBody] UpdateTrainingCategoryRequest updateTrainingCategory)
    {
        var result = await _trainingCategoryRepository.UpdateTrainingCategoryAsync(updateTrainingCategory);

        return Ok(result);
    }

    /// <summary>
    /// Удаление категории подготовки
    /// </summary>
    [HttpDelete("delete/{trainingCategoryId}")]
    [Consumes(MediaTypeNames.Application.Json)]
    public async Task<IActionResult> DeleteSubject(Guid trainingCategoryId)
    {
        await _trainingCategoryRepository.DeleteTrainingCategoryAsync(trainingCategoryId);

        return Ok("Категория подготовки успешно удалена");
    }
}