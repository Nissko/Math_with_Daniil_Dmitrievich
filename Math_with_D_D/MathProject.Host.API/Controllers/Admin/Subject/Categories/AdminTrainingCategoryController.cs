using System.Net.Mime;
using MathProject.Host.Application.Application.Interfaces.Subject.Categories;
using MathProject.Host.Application.Application.Templates.Request.Subject.Categories.DirectionOfTrainingRequests;
using MathProject.Host.Application.Application.Templates.Request.Subject.Categories.TrainingCategoryRequests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MathProject.Host.API.Controllers.Admin.Subject.Categories
{
    [ApiController]
    [Route("[controller]/admin/")]
    public class AdminTrainingCategoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ITrainingCategoryRepository _trainingCategoryRepository;

        public AdminTrainingCategoryController(IMediator mediator,
            ITrainingCategoryRepository trainingCategoryRepository)

        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _trainingCategoryRepository = trainingCategoryRepository ??
                                          throw new ArgumentNullException(nameof(trainingCategoryRepository));
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
}