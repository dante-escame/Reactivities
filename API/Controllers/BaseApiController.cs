using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace API.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class BaseApiController : ControllerBase
  {
    private IMediator _mediator;

    // If the property on the left is null, then Mediator will be assigned by ...
    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
  }
}
