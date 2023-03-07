using Application.Features.Pizza;
using Application.Features.Pizza.Command;
using Application.Features.Pizza.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PizzaController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet("GetAllPizzas")]
        public async Task<IActionResult> Get()
        {
            var pizzas = await _mediator.Send(new GetAllPizzaQuery());
            return Ok(pizzas);
        }

        [HttpGet("GetById/{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            var pizzas = await _mediator.Send(new GetPizzaByIdQuery() { Id = Id });
            return Ok(pizzas);
        }

        [HttpPost("Create")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> Create(PizzaDto pizza)
        {
            var pizzas = await _mediator.Send(new CreatePizzaCommand() { Pizza = pizza });
            return Ok(pizzas);
        }

        [HttpPost("Update")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> Update(PizzaDto pizza)
        {
            var pizzas = await _mediator.Send(new CreatePizzaCommand() { Pizza = pizza });
            return Ok(pizzas);
        }
    }
}
