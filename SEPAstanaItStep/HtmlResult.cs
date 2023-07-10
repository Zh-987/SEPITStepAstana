using Microsoft.AspNetCore.Mvc;

namespace SEPAstanaItStep
{
    public class HtmlResult : IActionResult 
    {
        string htmlCode;
        public HtmlResult(string html) { 
        htmlCode = html;
        }
        public async Task ExecuteResultAsync(ActionContext context) {
            string fullHtmlCode = $@"<!DOCTYPE html>

<html>
<head>
<title>IT STEP</title>
<meta charset=utf-8/>
</head>
<body>{htmlCode}</body>
</html>
";

            await context.HttpContext.Response.WriteAsync(fullHtmlCode);
        }
    }
}
