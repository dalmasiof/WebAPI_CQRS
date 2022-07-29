using Application.DTOs;
using Application.Features.CustomerType.Request.Command;
using Application.Features.CustomerType.Request.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CostumerController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CostumerController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<CostumerController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var costumers = await _mediator.Send(new CostumerListRequest());
            return Ok(costumers);
        }

        // GET api/<CostumerController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var costumers = await _mediator.Send(new CostumerDetailsRequest().Id = id);
            return Ok(costumers);
        }

        // POST api/<CostumerController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CostumerDTO costumerDTO )
        {
            var command = new CreateCostumerCommand() { costumer = costumerDTO };
            var costumers = await _mediator.Send(command);
            return Ok(costumers);
        }

        // PUT api/<CostumerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CostumerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
