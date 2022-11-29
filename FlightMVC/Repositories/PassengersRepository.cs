using FlightMVC.Models;
using System.Xml.Linq;

namespace FlightMVC.Repositories
{
  public class PassengersRepository : IPassengersRepository
  {
    static List<PassengerDetails> _passengers = new List<PassengerDetails>();
    static PassengersRepository()
    {
      for (int i = 0; i < 10; i++)
      {
        _passengers.Add(new PassengerDetails($"Fred{i}", 10 + i,$"AL12{i}"));
      }
    }
    public void AddPassenger(PassengerDetails passenger)
    {
      _passengers.Add(passenger);
    }
    public void DeletePassenger(string name)
    {
      var pd = _passengers.FirstOrDefault(p => p.Name == name);
      _passengers.Remove(pd);
    }
    public IEnumerable<PassengerDetails> GetPassengers()
    {
      return _passengers;
    }
    public void UpdatePassenger(PassengerDetails passenger)
    {
      var pd = _passengers.FirstOrDefault(p => p.Name == passenger.Name);
      _passengers.Remove(pd);
      _passengers.Add(passenger);
    }
  }
}
