using MathProject.Host.Application.Application.Interfaces.Subject.Categories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MathProject.Host.API.Controllers.Subject.Categories;

[ApiController]
[Route("api/[controller]")]
public class DirectionOfTrainingController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IDirectionOfTrainingRepository _repository;

    public DirectionOfTrainingController(IMediator mediator, IDirectionOfTrainingRepository repository)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }
}