using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Register.Application.Exceptions;
using Register.Application.Features.Operations.Commands.CreateOperation;
using Register.Application.Features.Operations.Commands.DeleteOperation;
using Register.Application.Features.Operations.Commands.UpdateOperation;
using Register.Application.Features.Operations.Queries.GetOperation;
using Register.Application.ViewModels;
using System;
using System.Threading.Tasks;

namespace Register.API.Controllers
{
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [ApiController]
    public class OperationsController : MainController
    {
        private readonly IMediator _mediator;

        public OperationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get a operation
        /// </summary>
        /// <param name="id">The id of the operation</param>
        /// <returns>An ActionResult of type Operation</returns>
        /// <response code="404">Operation not found</response>
        [HttpGet("{id}", Name = "GetOperationByIdAsync")]
        [ProducesResponseType(typeof(OperationVm), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<OperationVm>> GetOperationByIdAsync(Guid id)
        {
            var query = new GetOperationQuery(id);
            var operation = await _mediator.Send(query);
            if (operation is null)
            {
                return NotFound(new { success = false, data = "Operation not found." });
            }
            return Ok(operation);
        }

        /// <summary>
        /// Create a operation
        /// </summary>
        /// <param name="command">The create operation command object</param>
        /// <returns>An ActionResult of type Operation</returns>
        /// <response code="404">Operation not found</response>
        /// <response code="400">The command object did not pass the validation</response>
        [HttpPost(Name = "CreateOperationAsync")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Guid>> CreateOperationAsync([FromBody] CreateOperationCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                return CreatedAtRoute(nameof(OperationsController.GetOperationByIdAsync), new { operationId = result }, null);
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
        /// Update a operation
        /// </summary>
        /// <param name="command">The update operation command object</param>
        /// <param name="id">The id of the operation to be updated</param>
        /// <response code="404">Operation not found</response>
        /// <response code="400">The command object did not pass the validation</response>
        [HttpPut(Name = "UpdateOperationAsync")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateOperationAsync([FromBody] UpdateOperationCommand command, Guid id)
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

        /// <summary>
        /// Delete a operation
        /// </summary>
        /// <param name="id">The id of the operation to be deleted</param>
        /// <response code="404">Operation not found</response>
        [HttpDelete("{id}", Name = "DeleteOperationAsync")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteOperationAsync(Guid id)
        {
            try
            {
                var command = new DeleteOperationCommand() { Id = id };
                await _mediator.Send(command);
                return NoContent();
            }
            catch (NotFoundException validation)
            {
                return NotFoundExceptionResponse(validation);
            }
        }
    }
}