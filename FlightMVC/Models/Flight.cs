using System.ComponentModel.DataAnnotations;

namespace FlightMVC.Models
{
  public class Flight
  {
    [Key]
    public int Id { get; set; }
    [Required]
    [StringLength(6, ErrorMessage ="{0} length less or equal to {1}!")]
    public string FlightNo { get; set; }
    [Required]
    [StringLength(50, ErrorMessage = "{0} length less or equal to {1}!")]
    public string Origin { get; set; }
    [Required]
    [StringLength(50, ErrorMessage = "{0} length less or equal to {1}!")]
    public string Destination { get; set; }
  }
}
