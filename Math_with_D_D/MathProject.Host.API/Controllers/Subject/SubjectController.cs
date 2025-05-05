using System.Net.Mime;
using MathProject.Host.Application.Application.Interfaces.Subject;
using MathProject.Host.Application.Application.Templates.Request.Subject;
using MathProject.Host.Application.Application.Templates.Request.Subject.Categories.TrainingCategoryRequests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MathProject.Host.API.Controllers.Subject;

[ApiController]
[Route("api/[controller]")]
public class SubjectController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ISubjectRepository _subjectRepository;

    public SubjectController(IMediator mediator, ISubjectRepository subjectRepository)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        _subjectRepository = subjectRepository ?? throw new ArgumentNullException(nameof(subjectRepository));
    }

    /// <summary>
    /// Получение списка предметов
    /// </summary>
    [HttpGet("")]
    [Consumes(MediaTypeNames.Application.Json)]
    public async Task<IActionResult> GetSubjects()
    {
        var result = await _subjectRepository.GetSubjectsAsync();
        
        return Ok(result);
    }
    
    /// <summary>
    /// Получение определенного предмета
    /// </summary>
    [HttpGet("{subjectId}")]
    [Consumes(MediaTypeNames.Application.Json)]
    public async Task<IActionResult> GetSubjectFromId(Guid subjectId)
    {
        if (subjectId == Guid.Empty) return BadRequest("Неверный идентификатор предмета");
        var result = await _subjectRepository.GetSubjectByIdAsync(subjectId);
        
        return Ok(result);
    }

    /// <summary>
    /// Добавление нового предмета
    /// </summary>
    [HttpPost("create")]
    [Consumes(MediaTypeNames.Application.Json)]
    public async Task<IActionResult> CreateSubject([FromBody] CreateSubjectRequest newSubject)
    {
        var result = await _subjectRepository.CreateSubjectAsync(newSubject);
        
        return Ok(result);
    }

    /// <summary>
    /// Добавление новых категорий подготовки
    /// </summary>
    [HttpPost("add/training-categories")]
    [Consumes(MediaTypeNames.Application.Json)]
    public async Task<IActionResult> AddTrainingCategories([FromBody] AddTrainingCategoriesRequest addTrainingCategories)
    {
        var result = await _subjectRepository.AddTrainingCategoriesAsync(addTrainingCategories);
        
        return Ok(result);
    }

    /// <summary>
    /// Изменение названия существующего предмета
    /// </summary>
    [HttpPost("change")]
    [Consumes(MediaTypeNames.Application.Json)]
    public async Task<IActionResult> ChangeSubject([FromBody] UpdateSubjectRequest updateSubject)
    {
        var result = await _subjectRepository.UpdateSubjectAsync(updateSubject);

        return Ok(result);
    }

    /// <summary>
    /// Удаление предмета по Id
    /// </summary>
    [HttpDelete("delete/{subjectId}")]
    [Consumes(MediaTypeNames.Application.Json)]
    public async Task<IActionResult> DeleteSubject(Guid subjectId)
    {
        await _subjectRepository.DeleteSubjectAsync(subjectId);

        return Ok("Предмет успешно удален");
    }
}