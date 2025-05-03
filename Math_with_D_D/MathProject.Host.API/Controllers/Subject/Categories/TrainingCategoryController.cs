using System.Net.Mime;
using MathProject.Host.Application.Application.Interfaces.Subject.Categories;
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
    [HttpGet("get_training_categories_subjects")]
    [Consumes(MediaTypeNames.Application.Json)]
    public async Task<IActionResult> GetAllTrainingCategoriesAsync()
    {
        var result = await _trainingCategoryRepository.GetTrainingCategoriesAsync();

        return Ok(result.OrderBy(t => t.DisplayOrder).GroupBy(t => t.SubjectName));
    }
    
    /// <summary>
    /// Получить все категории предметов по ид предмета
    /// </summary>
    [HttpGet("get_training_categories_from_subjectId")]
    [Consumes(MediaTypeNames.Application.Json)]
    public async Task<IActionResult> GetAllTrainingCategoriesFromSubjectIdAsync([FromQuery] Guid subjectId)
    {
        var result = await _trainingCategoryRepository.GetTrainingCategoriesFromSubjectIdAsync(subjectId);

        return Ok(result.OrderBy(t => t.DisplayOrder));
    }

    /// <summary>
    /// Изменение категории подготовки
    /// </summary>
    [HttpPost("change_training_category")]
    [Consumes(MediaTypeNames.Application.Json)]
    public async Task<IActionResult> ChangeSubject([FromBody] UpdateTrainingCategoryRequest updateTrainingCategory)
    {
        var result = await _trainingCategoryRepository.UpdateTrainingCategoryAsync(updateTrainingCategory);

        return Ok(result);
    }

    /// <summary>
    /// Удаление категории подготовки
    /// </summary>
    [HttpDelete("delete_training_сategory")]
    [Consumes(MediaTypeNames.Application.Json)]
    public async Task<IActionResult> DeleteSubject([FromQuery] Guid trainingCategoryId)
    {
        await _trainingCategoryRepository.DeleteTrainingCategoryAsync(trainingCategoryId);

        return Ok("Категория подготовки успешно удалена");
    }
}