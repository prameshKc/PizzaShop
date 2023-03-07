using API.Authenticaion;
using Application.Features.Login;
using Application.Features.Login.Query;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LoginController(IMediator mediator)
        {
            this._mediator = mediator;
        }


        [HttpPost("Login")]
        public async Task<IActionResult> LoginUser([FromBody] LoginUser login)
        {
            var response = await  _mediator.Send(new GetUserByCredentialQuery() { UserName = login.Username, Password = login.Password });
            return Ok(response);

        }
    }
}
