using System.Threading.Tasks;
using Application.Features.Clientes.Commands.CreateClienteCommand;
using Application.Features.Clientes.Commands.DeleteClienteCommand;
using Application.Features.Clientes.Commands.UpdateClienteCommand;
using Application.Features.Clientes.Queries.GetClienteById;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    public class ClientesController : BaseApiController
    {
        //GET: api/<controller>/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id) => Ok(await Mediator.Send(new GetClienteByIdQuery {Id = id}));


        //POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateClienteCommand command) => Ok(await Mediator.Send(command));

        //PUT api/<controller>/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, UpdateClienteCommand command)
        {
            command.Id = id;
            return Ok(await Mediator.Send(command));
        }

        //DELETE api/<controller>/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Put(int id) => Ok(await Mediator.Send(new DeleteClienteCommand {Id = id}));
    }
}