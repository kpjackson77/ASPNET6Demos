using FlightMVC.Models;

namespace FlightMVC.Repositories
{
  public interface IPassengersRepository
  {
    IEnumerable<PassengerDetails> GetPassengers();
    void AddPassenger(PassengerDetails passenger);
    void UpdatePassenger(PassengerDetails passenger);
    void DeletePassenger(string name);
  }
}
