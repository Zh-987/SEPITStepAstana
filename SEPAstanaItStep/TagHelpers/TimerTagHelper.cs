using Microsoft.AspNetCore.Razor.TagHelpers;

namespace SEPAstanaItStep.TagHelpers
{
    public class TimerTagHelper : TagHelper  //<timer> </timer>  <timer/>  <br/>
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.TagMode = TagMode.StartTagAndEndTag;

            output.PreElement.SetHtmlContent("<h4>Date and Time</h4>");

            output.PostElement.SetHtmlContent($"<div>Current Date: {DateTime.Now.ToString("dd/mm/yyyy")}</div>");

            output.Attributes.SetAttribute("style", "color:blue");
            output.Attributes.SetAttribute("class", "timer");

            output.Content.SetContent($"<div>Current Time: {DateTime.Now.ToString("HH:mm:ss")}</div>");
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
