using Microsoft.AspNetCore.Mvc;

namespace Northwind.Presentation.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class MgmtController : ControllerBase
{
    [HttpGet]
    public IActionResult HealthCheck()
    {
        return Ok();
    }
}