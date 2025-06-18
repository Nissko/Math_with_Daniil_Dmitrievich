using System.Net.Mime;
using MathProject.Host.Application.Application.Interfaces.Subject;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MathProject.Host.API.Controllers.Subject;

[ApiController]
[Route("[controller]")]
public class SubjectController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ISubjectRepository _subjectRepository;

    /// <summary>
    /// TODO:
    /// Методы которые нужно сделать:
    /// 1) Получение всех предметов
    /// 2) Получение 1 предмета по id
    /// 3) Получение категорий подготовки предмета по id предмета
    /// 4) Добавление нового предмета ***вынести в отдельный контроллер Admin***
    /// 5) Добавление новых категорий подготовки предмета ***вынести в отдельный контроллер Admin***
    /// 6) Изменение предмета (название) ***вынести в отдельный контроллер Admin***
    /// 7) Удаление предмета ??? (Узнать...) ***вынести в отдельный контроллер Admin***
    /// 
    /// </summary>
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
    /// Получение категорий подготовки по id-предмета
    /// </summary>
    [HttpGet("get-training-categories/{subjectId}")]
    [Consumes(MediaTypeNames.Application.Json)]
    public async Task<IActionResult> GetTrainingCategoriesFromSubjectId(Guid subjectId)
    {
        if (subjectId == Guid.Empty) return BadRequest("Неверный идентификатор предмета");
        var result = await _subjectRepository.GetTrainingCategoryByIdAsync(subjectId);
        
        return Ok(result);
    }
}