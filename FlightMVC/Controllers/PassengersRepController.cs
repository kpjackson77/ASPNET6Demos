using FlightMVC.Models;
using FlightMVC.Repositories;
using FlightMVC.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightMVC.Controllers
{
  public class PassengersRepController : Controller
  {
    private IPassengersRepository _repository;

    public PassengersRepController(IPassengersRepository repository)
    {
      _repository = repository;
    }
    // GET: PassengersController
    public ActionResult Index()
    {
      return View(_repository.GetPassengers());
    }

    // GET: PassengersController/Details/5
    public ActionResult Details(string id)
    {
      return FindAndDisplay(id);
    }
    private ActionResult FindAndDisplay(string id)
    {
      var pd = _repository.GetPassengers().FirstOrDefault(p => p.Name == id);

      if (pd == null) return NotFound();

      return View(pd);
    }

    // GET: PassengersController/Create
    public ActionResult Create()
    {
      return View();
    }

    // POST: PassengersController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(PassengerDetails collection)
    {
      if (ModelState.IsValid)
      {
        try
        {
          _repository.AddPassenger(collection);
          return RedirectToAction(nameof(Index));
        }
        catch
        {
          return View(collection);
        }
      }
      else
      {
        return View(collection);
      }
    }

    // GET: PassengersController/Edit/5
    public ActionResult Edit(string id)
    {
      return FindAndDisplay(id);
    }

    // POST: PassengersController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(string id, PassengerDetails collection)
    {
      if (ModelState.IsValid)
      {
        try
        {

          var pd = _repository.GetPassengers().FirstOrDefault(p => p.Name == id);

          if (pd == null) return NotFound();

          _repository.UpdatePassenger(collection);

          return RedirectToAction(nameof(Index));
        }
        catch
        {
          return View(collection);
        }
      }
      else
      {
        return View(collection);
      }
    }
    
    // GET: PassengersController/Delete/5
    public ActionResult Delete(string id)
    {
      return FindAndDisplay(id);
    }
    // POST: PassengersController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(string id, PassengerDetails collection)
    {
      try
      {
        _repository.DeletePassenger(id);

        return RedirectToAction(nameof(Index));
      }
      catch
      {
        return View(collection);
      }
    }
    public ActionResult GetChanges()
    {
      var json = HttpContext.Session.GetString(ConstStrings.Changes);
      List<PassengerDetails>? changes = null;
      if (json != null)
      {
        changes = Newtonsoft.Json.JsonConvert.DeserializeObject<List<PassengerDetails>>(json);
      }
      else
      {
        changes = new List<PassengerDetails>();
      }

      return View(changes);
    }
  }
}
