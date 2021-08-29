using Microsoft.AspNetCore.Mvc;
using Register.Application.Exceptions;
using System.Linq;

namespace Register.API.Controllers
{
    [ApiController]
    public class MainController : ControllerBase
    {
        protected ActionResult ValidationExceptionResponse(ValidationException ex)
        {
            return BadRequest(new { success = false, errors = ex.Errors.Select(n => n.Value), data = ex.Message });
        }

        protected ActionResult NotFoundExceptionResponse(NotFoundException ex)
        {
            return NotFound(new { success = false, data = ex.Message });
        }
    }
}