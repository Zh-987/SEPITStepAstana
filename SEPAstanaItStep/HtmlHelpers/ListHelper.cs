using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Text.Encodings.Web;

namespace SEPAstanaItStep.Helpers
{
    public static class ListHelper
    {
        public static HtmlString CreateList(this IHtmlHelper html, string[] items) {
            TagBuilder ul = new TagBuilder("ul"); //<ul> </ul>
            foreach (string item in items) {
                TagBuilder li = new TagBuilder("li"); //<li> </li>
                li.InnerHtml.Append(item);
                ul.InnerHtml.AppendHtml(li);
            }
            ul.Attributes.Add("class", "itemsList");
            using var writer = new StringWriter();
            ul.WriteTo(writer, HtmlEncoder.Default);
            //AddCssClass()
            return new HtmlString(writer.ToString());
        }
    }
}
