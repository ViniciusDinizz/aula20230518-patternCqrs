using Cqrs.Domain.Commands.CreatePerson;
using Cqrs.Domain.Commands.DeletePerson;
using Cqrs.Domain.Commands.UpdatePerson;
using Cqrs.Domain.Core;
using Cqrs.Domain.Domain;
using Cqrs.Domain.Queries.GetPerson;
using Cqrs.Domain.Queries.ListPerson;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cqrs.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly CreatePersonCommandHandler _createPersonCommandHandler;
        private readonly ListPersonQueryHandle _listPersonQueryHandler;
        private readonly DeletePersonCommandHandler _deletePersonCommandHandler;
        private readonly GetPersonQueryHandler _getPersonQueryHandler;
        private readonly UpdatePersonCommandHandler _updatePersonCommandHandler;

        public PeopleController(
            CreatePersonCommandHandler createPersonCommandHandler, 
            ListPersonQueryHandle listPersonQueryHandle,
            DeletePersonCommandHandler deletePersonCommandHandler,
            GetPersonQueryHandler getPersonQueryHandler,
            UpdatePersonCommandHandler updatePersonCommandHandler) 
        {
            _createPersonCommandHandler = createPersonCommandHandler;
            _listPersonQueryHandler = listPersonQueryHandle;
            _deletePersonCommandHandler = deletePersonCommandHandler;
            _getPersonQueryHandler = getPersonQueryHandler;
            _updatePersonCommandHandler = updatePersonCommandHandler;
        }

        [HttpPost(Name = "Insert Person")]
        public async Task<Guid> InsertPeopleAsync(
            CreatePersonCommand createPersonCommand, 
            CancellationToken cancellationToken)
        {
            return await _createPersonCommandHandler
                .HandleAsync(createPersonCommand, cancellationToken);
        }

        [HttpGet(Name = "Get People")]
        public async Task<IEnumerable<ListePersonQueryResponse>> GetPeopleAsync([FromQuery] string? name, [FromQuery] string? cpf, CancellationToken cancellationToken)
        {
            return await _listPersonQueryHandler.HandleAsync(new ListPersonQuery(name, cpf), cancellationToken); 
        }

        [HttpGet("{id:guid}", Name = "Get Person BY Id")]
        public async Task<IActionResult> GetAsync([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var response = await _getPersonQueryHandler.HandleAsync(new GetPersonQuery(id), cancellationToken);
            return GetResponse(_getPersonQueryHandler, response);
        }

        [HttpDelete("{id:guid}",Name = "Delete Person")]
        public async Task<IActionResult> DeletePersonAsync([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            await _deletePersonCommandHandler.HandleAsync(new DeletePersonCommand(id), cancellationToken);

            return Ok();
        }

        [HttpPut("{id:guid}", Name = "Update Person")]
        public async Task<IActionResult> UpdatePersonAsync([FromRoute] Guid id, [FromBody] UpdatePersonCommand command, CancellationToken cancellationToken)
        {
            command.Id = id;
            var response = await _updatePersonCommandHandler.HandleAsync(command, cancellationToken);

            return GetResponse(_updatePersonCommandHandler, response);
        }

        private IActionResult GetResponse<THandler, TResponse>(THandler handler, TResponse response) where THandler : BaseHandler
        {
            return StatusCode((int)handler.GetStatusCode(),new
                {
                    Data = response,
                    Notifications = handler.GetNotifications(),
                });
        }

        private IActionResult GetResponse<THandler>(THandler handler) where THandler : BaseHandler
        {
            return StatusCode((int)handler.GetStatusCode(),
                new {Notifications = handler.GetNotifications()});
        }
    }
}
