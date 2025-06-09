// https://cheatsheetseries.owasp.org/cheatsheets/XML_External_Entity_Prevention_Cheat_Sheet.html#net
using Microsoft.AspNetCore.Mvc;
using System.Xml;
using System.Xml.XPath;
using System.Text;

[ApiController]
[Route("test")]
public class Program : Controller
{
    [HttpGet]
    [Route("a")]
    public JsonResult GetMessage()
    {
        try
        {
            string fileData = System.IO.File.ReadAllText("file.txt");

            return Json(new { success = true });
        }
        catch (Exception e)
        {
            ModelState.AddModelError("", e.Message);
            return Json(new { success = false, message = e.Message });
        }
    }

    [HttpGet]
    [Route("b")]
    public JsonResult GetMessageStringPatcherLast()
    {
        try
        {
            string fileData = System.IO.File.ReadAllText("file.txt");

            return Json(new { success = true });
        }
        catch (Exception e)
        {
            ModelState.AddModelError("", "had an error " + e.Message);
            return Json(new { success = false, message = "had an error " + e.Message });
        }
    }

    [HttpGet]
    [Route("c")]
    public JsonResult GetMessageStringPatcherFirst()
    {
        try
        {
            string fileData = System.IO.File.ReadAllText("file.txt");

            return Json(new { success = true });
        }
        catch (Exception e)
        {
            ModelState.AddModelError("", e.Message + ", had an error");
            return Json(new { success = false, message = e.Message + ", had an error" });
        }
    }

    [HttpGet]
    [Route("d")]
    public JsonResult GetMessageStringPatcherMiddleVar()
    {
        string var = "var";
        try
        {
            string fileData = System.IO.File.ReadAllText("file.txt");

            return Json(new { success = true });
        }
        catch (Exception e)
        {
            ModelState.AddModelError("", "had an error " + e.Message + var);
            return Json(new { success = false, message = "had an error " + e.Message + var });
        }
    }

    [HttpGet]
    [Route("e")]
    public JsonResult GetMessageStringPatcherMiddleString()
    {
        string var = "var";
        try
        {
            string fileData = System.IO.File.ReadAllText("file.txt");

            return Json(new { success = true });
        }
        catch (Exception e)
        {
            ModelState.AddModelError("", "had an error " + e.Message + " with more details " + var);
            return Json(new { success = false, message = "had an error " + e.Message + " with more details " + var});
        }
    }

    [HttpGet]
    [Route("f")]
    public JsonResult GetObject()
    {
        try
        {
            string fileData = System.IO.File.ReadAllText("file.txt");

            return Json(new { success = true });
        }
        catch (Exception e)
        {
            ModelState.AddModelError("", e, null);
            return Json(new { success = false, message = e });
        }
    }

    static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllers();
        var app = builder.Build();
        app.MapControllers();
        app.Run();
    }
}
