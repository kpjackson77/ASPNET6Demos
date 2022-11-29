using FlightMVC.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace FlightMVC.Components
{
  public class FlightViewComponent:ViewComponent
  {
    ApplicationDbContext _ctx;
    public FlightViewComponent(ApplicationDbContext ctx)
    {
      _ctx = ctx;
    }
    public IViewComponentResult Invoke(string flightNo)
    {
      var flight = _ctx.Flights.FirstOrDefault(fl => fl.FlightNo == flightNo);

      return View(flight);
    }
  }
}
