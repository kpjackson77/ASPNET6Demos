using FlightMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace FlightMVC.Components
{
  public class QuestionAnswerViewComponent:ViewComponent
  {
    public IViewComponentResult Invoke(string q, string a)
    {
      QuestionAnswer qa = new QuestionAnswer() { Question = q, Answer = a };

      return View(qa);
    }
  }
}
