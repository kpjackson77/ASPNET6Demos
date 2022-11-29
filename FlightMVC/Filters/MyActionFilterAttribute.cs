using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FlightMVC.Filters
{
  public class MyActionFilterAttribute :ActionFilterAttribute
  {
    ILogger _logger;
    public MyActionFilterAttribute(ILoggerFactory loggerFactory)
    {
      _logger = loggerFactory.CreateLogger<MyActionFilterAttribute>();
    }
    public override void OnActionExecuting(ActionExecutingContext context)
    {
      _logger.LogInformation(nameof(OnActionExecuting));
      base.OnActionExecuting(context);
    }
    public override void OnActionExecuted(ActionExecutedContext context)
    {
      _logger.LogInformation(nameof(OnActionExecuted));
      base.OnActionExecuted(context);
    }
    public override void OnResultExecuting(ResultExecutingContext context)
    {
      _logger.LogInformation(nameof(OnResultExecuting));
      var vr = context.Result as ViewResult;
      if( vr != null)
      {
        var model = vr.Model;
      }
      base.OnResultExecuting(context);
    }
    public override void OnResultExecuted(ResultExecutedContext context)
    {
      _logger.LogInformation(nameof(OnResultExecuted));
      base.OnResultExecuted(context);
    }
  }
}
