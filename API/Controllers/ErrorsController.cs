using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class ErrorsController : ControllerBase
{
    [Route("/error")]
    public IActionResult Error() => Problem();
}