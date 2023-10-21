using Microsoft.AspNetCore.Mvc;

namespace Rsoi.Lab2.GatewayService.HttpApi.Controllers;

public class HealthController : ControllerBase
{
    [HttpGet]
    [Route("manage/health")]
    public IActionResult HealthCheck()
    {
        return Ok();
    }
}