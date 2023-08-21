using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SEPAstanaItStep.TagHelpers
{
    public class TimerTagHelper : TagHelper  //<timer> </timer>  <timer/>  <br/>
    {
        ITimeService _timeService;

        [ViewContext]
        [HtmlAttributeName]
        public ViewContext? ViewContext { get; set; }
        public TimerTagHelper(ITimeService timeService) { 
            _timeService = timeService;
        }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            string? font = ViewContext?.HttpContext.Request.Query["font"];

            if (string.IsNullOrEmpty(font)) {
                font = "Verdana";
            }

            output.Attributes.SetAttribute("style", $"font-family:{font}; font-size:16px;");
            output.TagName = "div";
            output.TagMode = TagMode.StartTagAndEndTag;

            output.PreElement.SetHtmlContent("<h4>Date and Time</h4>");

            output.PostElement.SetHtmlContent($"<div>Current Date: {DateTime.Now.ToString("dd/mm/yyyy")}</div>");

            output.Attributes.SetAttribute("style", "color:blue");
            output.Attributes.SetAttribute("class", "timer");

            output.Content.SetContent($"Current Time: {_timeService.Time}");
        }
    }
    //<h4>Date and Time</h4>
    //<div>Current Time 01:01:01</div>
    //<div>Current Date 01.01.01</div>
    public class DateTagHelper : TagHelper {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Content.SetContent($"Current Date: {DateTime.Now.ToString("dd/mm/yyyy")}");
        }
    }

    public class SummaryTagHelper : TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            var target = await output.GetChildContentAsync();
            var content = "<h3>General Info</h3>" + target.GetContent();
            output.Content.SetHtmlContent(content);
        }
    }
}
