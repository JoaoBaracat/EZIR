using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Register.Application.Exceptions;
using Register.Application.Features.OperationTypes.Commands.CreateOperationType;
using Register.Application.Features.OperationTypes.Commands.UpdateOperationType;
using Register.Application.Features.OperationTypes.Queries.GetOperationType;
using Register.Application.ViewModels;
using System;
using System.Threading.Tasks;

namespace Register.API.Controllers
{
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class OperationTypesController : MainController
    {
        private readonly IMediator _mediator;

        public OperationTypesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get a operation type
        /// </summary>
        /// <param name="id">The id of the operation type</param>
        /// <returns>An ActionResult of type OperationType</returns>
        /// <response code="404">Operation type not found</response>
        [HttpGet("{id}", Name = "GetOperationTypeByIdAsync")]
        [ProducesResponseType(typeof(OperationTypeVm), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<OperationTypeVm>> GetOperationTypeByIdAsync(Guid id)
        {
            var query = new GetOperationTypeQuery(id);
            var operationType = await _mediator.Send(query);
            if (operationType is null)
            {
                return NotFound(new { success = false, data = "Operation type not found." });
            }
            return Ok(operationType);
        }

        /// <summary>
        /// Create a operation type
        /// </summary>
        /// <param name="command">The create operation type command object</param>
        /// <returns>An ActionResult of Guid returning the id of the Operation Type</returns>
        /// <response code="404">Operation type not found</response>
        /// <response code="400">The command object did not pass the validation</response>
        [HttpPost(Name = "CreateOperationTypeAsync")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Guid>> CreateOperationTypeAsync([FromBody] CreateOperationTypeCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                return CreatedAtRoute(nameof(OperationTypesController.GetOperationTypeByIdAsync), new { id = result }, null);
            }
            catch (ValidationException validation)
            {
                return ValidationExceptionResponse(validation);
            }
            catch (NotFoundException validation)
            {
                return NotFoundExceptionResponse(validation);
            }
        }

        /// <summary>
        /// Update a operation type
        /// </summary>
        /// <param name="command">The update operation type command object</param>
        /// <param name="id">The id of the operation type to be updated</param>
        /// <response code="404">Operation type not found</response>
        /// <response code="400">The command object did not pass the validation</response>
        [HttpPut(Name = "UpdateOperationTypeAsync")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateOperationTypeAsync([FromBody] UpdateOperationTypeCommand command, Guid id)
        {
            try
            {
                if (id != command.Id)
                {
                    return BadRequest(new { success = false, errors = "The command id is not equal to the id" });
                }
                await _mediator.Send(command);
                return NoContent();
            }
            catch (ValidationException validation)
            {
                return ValidationExceptionResponse(validation);
            }
            catch (NotFoundException validation)
            {
                return NotFoundExceptionResponse(validation);
            }
        }
    }
}