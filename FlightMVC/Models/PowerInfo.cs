namespace FlightMVC.Models
{
  public record PowerInfoVM(int Number)
  {
    public int Square => Number * Number;
    public int Cube => Square*Number;
  }
}
