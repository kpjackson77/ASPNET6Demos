using Microsoft.AspNetCore.Mvc;

namespace FlightMVC.Controllers
{
  public class SimpleController
  {
    public IActionResult SomeText()
    {
      return new ContentResult() { Content = "The answer is 42" };
    }
  }
}
