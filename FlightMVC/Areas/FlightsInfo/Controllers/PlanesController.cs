using FlightMVC.Areas.FlightsInfo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightMVC.Areas.FlightsInfo.Controllers
{
  [Area("FlightsInfo")]
  public class PlanesController : Controller
  {
    static List<Plane> _planes = new List<Plane>();
    static PlanesController()
    {
      _planes.Add(new Plane() { Id = 1, Model = "Boeing 747", Colour = "Blue", Capacity = 420 });
      _planes.Add(new Plane() { Id = 2, Model = "Boeing 737", Colour = "Pale Blue", Capacity = 260 });
      _planes.Add(new Plane() { Id = 3, Model = "Boeing 747", Colour = "Blue", Capacity = 415 });

    }
    // GET: PlanesController
    public ActionResult Index()
    {
      return View(_planes);
    }

    // GET: PlanesController/Details/5
    public ActionResult Details(int id)
    {
      return View();
    }

    // GET: PlanesController/Create
    public ActionResult Create()
    {
      return View();
    }

    // POST: PlanesController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(IFormCollection collection)
    {
      try
      {
        return RedirectToAction(nameof(Index));
      }
      catch
      {
        return View();
      }
    }

    // GET: PlanesController/Edit/5
    public ActionResult Edit(int id)
    {
      return View();
    }

    // POST: PlanesController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, IFormCollection collection)
    {
      try
      {
        return RedirectToAction(nameof(Index));
      }
      catch
      {
        return View();
      }
    }

    // GET: PlanesController/Delete/5
    public ActionResult Delete(int id)
    {
      return View();
    }

    // POST: PlanesController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, IFormCollection collection)
    {
      try
      {
        return RedirectToAction(nameof(Index));
      }
      catch
      {
        return View();
      }
    }
  }
}
