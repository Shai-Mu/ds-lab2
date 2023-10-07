using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Rsoi.Lab2.LibrarySystem.Controllers;

public class HealthController : ControllerBase
{
    [HttpGet]
    [Route("manage/health")]
    public IActionResult HealthCheck()
    {
        return Ok();
    }
}