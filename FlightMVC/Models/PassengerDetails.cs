using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace FlightMVC.Models
{
  //public record PassengerDetails(string Name, int Weight) { }
  public class PassengerDetails
  {
    [Required]
    [StringLength(50, ErrorMessage ="{0} length less or equal {1}!")]
    public string Name { get; set; }
    //[BindNever]
    [Required]
    [Range(0,30, ErrorMessage ="{0} between {1} and {2}, inclusive!")]
    public int Weight { get; set; }
    [Required]
    [StringLength(6, ErrorMessage = "{0} length less or equal {1}!")]
    public string FlightNo { get; set; }
    public PassengerDetails()
    {
      Name = string.Empty;
    }
    public PassengerDetails(string name, int weight, string flightNo)
    {
      Name = name;
      Weight = weight;
      FlightNo = flightNo;
    }
  }
}
