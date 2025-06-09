using System;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

[Route("api")]
[ApiController]
public class Controller : ControllerBase
{
    [HttpGet("a1")]
    public OkObjectResult A1(string json)
    {
        Console.WriteLine(JsonConvert.DeserializeObject(json));
        return Ok("ok");
    }
}
