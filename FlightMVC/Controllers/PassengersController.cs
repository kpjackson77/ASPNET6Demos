using FlightMVC.Models;
using FlightMVC.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightMVC.Controllers
{
  [Authorize(Policy="adminPolicy")]//Roles = "Admin")]
  public class PassengersController : Controller
  {
    static List<PassengerDetails> _passengers = new List<PassengerDetails>();

    static PassengersController()
    {
      _passengers.Add(new PassengerDetails("Fred", 23,"AL123"));
      _passengers.Add(new PassengerDetails("Graham", 15,"AL124"));
    }
    // GET: PassengersController
    public ActionResult Index()
    {
      return View(_passengers);
    }

    // GET: PassengersController/Details/5
    public ActionResult Details(string id)
    {
      return FindAndDisplay(id);
    }
    private ActionResult FindAndDisplay(string id)
    {
      var pd = _passengers.FirstOrDefault(p => p.Name == id);

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
      var pd = _passengers.FirstOrDefault(p => p.Name == collection.Name);

      if (pd != null)
      {
        ModelState.AddModelError(string.Empty, "Name already exists!");
        return View(collection);
      }
      if (ModelState.IsValid)
      {
        try
        {
          _passengers.Add(collection);
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

          var pd = _passengers.FirstOrDefault(p => p.Name == id);

          if (pd == null) return NotFound();

          SaveChange(pd);

          _passengers.Remove(pd);
          _passengers.Add(collection);

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
    private void SaveChange(PassengerDetails pd)
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

      changes?.Add(pd);

      string objs = Newtonsoft.Json.JsonConvert.SerializeObject(changes);

      HttpContext.Session.SetString(ConstStrings.Changes, objs);
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
        var pd = _passengers.FirstOrDefault(p => p.Name == id);

        if (pd != null)
        {
          _passengers.Remove(pd);
        }

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
