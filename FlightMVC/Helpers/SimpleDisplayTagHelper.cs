using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace FlightMVC.Helpers
{
  [HtmlTargetElement("p", Attributes ="asp-for")]
  public class SimpleDisplayTagHelper:TagHelper
  {
    [HtmlAttributeName("asp-for")]
    public ModelExpression For { get; set; }
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
      if (context == null || output == null) throw new ArgumentNullException();
      var text = For.ModelExplorer.GetSimpleDisplayText();
      output.Content.SetContent(text);
    }
  }
}
