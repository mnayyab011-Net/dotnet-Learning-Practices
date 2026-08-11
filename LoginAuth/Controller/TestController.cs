using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace LoginAuth.Controllers;
[ApiController]
[Route("api/[controller]")]
public class TestController : ControllerBase
{
    [HttpGet]
    [Authorize]
    public IActionResult GetSecret()
    {
        return Ok(new
        {
            Message = "Welcome! You are authenticated."
        });
    }
}