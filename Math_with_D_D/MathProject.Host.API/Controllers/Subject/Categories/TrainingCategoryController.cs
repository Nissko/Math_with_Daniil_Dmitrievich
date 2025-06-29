﻿using System.Net.Mime;
using MathProject.Host.Application.Application.Interfaces.Subject.Categories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MathProject.Host.API.Controllers.Subject.Categories;

[ApiController]
[Route("[controller]")]
public class TrainingCategoryController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ITrainingCategoryRepository _trainingCategoryRepository;
    
    /// <summary>
    /// Категория подготовки
    /// </summary>
    public TrainingCategoryController(IMediator mediator, ITrainingCategoryRepository trainingCategoryRepository)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        _trainingCategoryRepository = trainingCategoryRepository ??
                                      throw new ArgumentNullException(nameof(trainingCategoryRepository));
    }

    /// <summary>
    /// Получение всех категорий подготовки
    /// </summary>
    [HttpGet("")]
    [Consumes(MediaTypeNames.Application.Json)]
    public async Task<IActionResult> GetAllTrainingCategories()
    {
        var result = await _trainingCategoryRepository.GetTrainingCategoriesAsync();

        return Ok(result.OrderBy(t => t.DisplayOrder).GroupBy(t => t.SubjectId));
    }
    
    /// <summary>
    /// Получение списка направлений обучения
    /// по id-категории подготовки
    /// </summary>
    [HttpGet("get-direction-trainings/{trainingCategoryId}")]
    [Consumes(MediaTypeNames.Application.Json)]
    public async Task<IActionResult> GetDirectionOfTrainingsFromTrainingCategoryId(Guid trainingCategoryId)
    {
        if (trainingCategoryId == Guid.Empty) return BadRequest("Неверный идентификатор категории подготовки");
        var result =
            await _trainingCategoryRepository.GetDirectionOfTrainingsFromTrainingCategoryId(trainingCategoryId);
        
        return Ok(result);
    }
}