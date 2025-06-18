using System.Net.Mime;
using MathProject.Host.Application.Application.Interfaces.Subject;
using MathProject.Host.Application.Application.Templates.Request.Subject;
using MathProject.Host.Application.Application.Templates.Request.Subject.Categories.TrainingCategoryRequests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MathProject.Host.API.Controllers.Admin.Subject
{
    [ApiController]
    [Route("[controller]/admin/")]
    public class AdminSubjectController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ISubjectRepository _subjectRepository;

        public AdminSubjectController(IMediator mediator, ISubjectRepository subjectRepository)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _subjectRepository = subjectRepository ?? throw new ArgumentNullException(nameof(subjectRepository));
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
}