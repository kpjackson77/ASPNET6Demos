using FlightMVC.Filters;
using FlightMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FlightMVC.Controllers
{
  public class DemosController : Controller
  {
    public IActionResult Index()
    {
      return View();
    }
    public IActionResult TagDemo()
    {
      return View(new PassengerDetails("Graham",23,"AL124"));
    }

    public IActionResult SomeContent()
    {
      return Content("The quick brown fox...");
    }

    public IActionResult DataViewOrBag()
    {
      ViewData["FoxText"] = "The quick brown fox jumps over the lazy dog!";

      ViewBag.Question = "The meaning of life the universe and everything?";

      return View();
    }
    public IActionResult SelectListDemo()
    {
      List<SelectListItem> items = new List<SelectListItem>();

      items.Add(new SelectListItem() { Text = "One", Value = "1", Selected = true });
      items.Add(new SelectListItem() { Text = "Two", Value = "2"});
      items.Add(new SelectListItem() { Text = "Three", Value = "3" });

      ViewData["Items"] = items;

      return View();
    }

    public IActionResult PowersDemo()
    {
      List<PowerInfoVM> powers = new List<PowerInfoVM>();

      for (int i = 0; i < 10; i++)
      {
        powers.Add(new PowerInfoVM(i));
      }

      return View(powers);
    }

    public IActionResult SomeAction() {
      return View("SomeAction", "The quick brown fox jumps over the lazy dog!");
    }
    public IActionResult QADemo()
    {
      QuestionAnswer qa = new QuestionAnswer() { Question = "The meaning of life?", Answer = "42" };

      return View(qa);
    }

    [NonAction]
    public string Message()
    {
      return "Greetings";
    }

    [ServiceFilter(typeof(MyActionFilterAttribute))]
    public IActionResult FilterDemo([FromServices]ILoggerFactory loggerFactory)
    {
      var logger = loggerFactory.CreateLogger("Action");
      logger.LogInformation("FilterDemo");
      return View();
    }

    public IActionResult FlightsServiceDemo()
    {
      return View();
    }
  }
}
