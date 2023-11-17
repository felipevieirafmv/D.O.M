using Microsoft.AspNetCore.Mvc;

namespace DomBack.Controllers;

using System;
using Services;
using DTO;

using Microsoft.Identity.Client;
using System.Threading.Tasks;

[ApiController]
[Route("user")]
public class UserController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Login(
        [FromBody]UserData user,
        [FromServices]IUserService service)
    {
        var logged = await service
            .GetByLogin(user.Login);
        
        if (logged.Senha != user.Password)
            return Ok("Deu erro kk");
        
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody]UserData user,
        [FromServices]IUserService service)
    {
        await service.Create(user);
        return Ok();
    }

    [HttpPut("image")]
    public IActionResult AddImage()
    {
        throw new NotImplementedException();
    }

    [HttpGet("image")]
    public IActionResult GetImage()
    {
        throw new NotImplementedException();
    }

    [HttpDelete("image")]
    public IActionResult RemoveImage()
    {
        throw new NotImplementedException();
    }

    [HttpDelete]
    public IActionResult DeleteUser()
    {
        throw new NotImplementedException();
    }
}