using MediatR;
using Microsoft.AspNetCore.Mvc;
using Register.Application.Features.Operations.Queries.GetOperation;
using Register.Application.ViewModels;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Register.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OperationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}", Name = "GetOperationById")]
        [ProducesResponseType(typeof(OperationVm), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<OperationVm>> GetOperationById(Guid id)
        {
            var query = new GetOperationQuery(id);
            var operation = await _mediator.Send(query);
            return Ok(operation);
        }
    }
}