using Application.Features.Pizza.Queries;
using Application.Features.Pizzeria.Command;
using Application.Features.Pizzeria.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzeriaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PizzeriaController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet("GetAllPizzeria")]
        public async Task<IActionResult> Get()
        {
            var pizzas = await _mediator.Send(new GetAllPizzeriaQuery());
            return Ok(pizzas);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int Id)
        {
            var pizzas = await _mediator.Send(new GetPizzeriaByIdQuery() { Id = Id });
            return Ok(pizzas);
        }

        [HttpPost("Create")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> Create(PizzeriaDto pizza)
        {
            var pizzas = await _mediator.Send(new CreatePizzeriaCommand() { PizzeriaDto = pizza });
            return Ok(pizzas);
        }
    }
}
