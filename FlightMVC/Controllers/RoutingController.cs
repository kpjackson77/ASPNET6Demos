using Microsoft.AspNetCore.Mvc;

namespace FlightMVC.Controllers
{
  [Route("TheRoot")]
  public class RoutingController : Controller
  {
    [HttpGet("TheIndex")]
    public IActionResult Index()
    {
      return Content("Got the index!!");
    }
    [HttpGet("Square/{n}")]
    public IActionResult Square(int n)
    {
      return Content($"Square of {n} = {n * n}");
    }
    [HttpGet("Multiply/{n1}/{n2}")]
    public IActionResult Mult(int n1, int n2)
    {
      return Content($"n1 * n2 = {n1*n2}");
    }
    [HttpGet("Number/{n:alpha}")]
    public IActionResult AlphaNumber(string n)
    {
      return Content($"Invalid: {n}");
    }
    [HttpGet("Number/{n:int:range(0,100)}")]
    public IActionResult SmallNumber(int n)
    {
      return Content($"Small number: {n}");
    }
    [HttpGet("Number/{n:int:range(101,100000)}")]
    public IActionResult LargeNumber(int n)
    {
      return Content($"Large number: {n}");
    }
  }
}
