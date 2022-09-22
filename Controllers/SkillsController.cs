using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Collections.Generic;

namespace SkillsTracker.Controllers
{
    public class SkillsController : Controller
    {
        [HttpGet]
        [Route("/skills")]
        public IActionResult Skills()
        {
            string html = @"
                <h1>Skills Tracker<h1>
                <h2>Coding skills to learn:<h2>
                <table>
                    <tr>
                        <th>Skill</th>
                    </tr>
                    <tr>
                        <td>Python</td>
                    </tr>
                    <tr>
                        <td>Javascript</td>
                    </tr>
                    <tr>
                        <td>C#</td>
                    </tr>
                    <tr>
                        <td>GLSL</td>
                    </tr>
                </table>
                ";

            return Content(html, "text/html");
        }

        [HttpPost]
        [Route("/skills")]
        public IActionResult Skills(IFormCollection formData)
        {

            StringBuilder page = new StringBuilder();
            string htmlStart = @"
                <h1>Skills Tracker</h1>
                <h2>Coding skills progress:</h2>
                <table>
                    <tr>
                        <th>Skill</th>
                        <th>Level</th>
                    </tr>
                ";
            page.Append(htmlStart);
            foreach (var field in formData)
            {
                if (!string.IsNullOrEmpty(field.Value.ToString()))
                { 
                    if (field.Key.ToString() == "date")
                    {
                        page.Insert(htmlStart.IndexOf('/') - 1, " " + field.Value.ToString());
                    }
                    else
                    {
                        page.AppendLine("<tr>");
                        page.AppendLine($"<td>{field.Key.ToString()}</td>");
                        page.AppendLine($"<td>{field.Value.ToString()}</td>");
                        page.AppendLine("</tr>");
                    }
                }
            }
            page.Append("</table>");

            return Content(page.ToString(), "text/html");

        }

        [HttpGet]
        [Route("/skills/form")]
        public IActionResult Form()
        {
            string html = @"
              <form method='post' action='/skills' >
                <label for='date'>Date:</label> <br> 
                <input type='date' name='date' id='date' required /> <br>
                <label for='pythonSelect'>Python:</label> <br>
                <select name='Python' id='pythonSelect' required> 
                    <option value='Basic'>Learning Basics</option>
                    <option value='Intermediate'>Competent Scripter</option>
                    <option value='Master'>I Can Explain PyTorch</option>
                </select> <br>
                <label for='javascriptSelect'>JavaScript:</label> <br>
                <select name='JavaScript' id='javascriptSelect' required> 
                    <option value='Basic'>Learning Basics</option>
                    <option value='Intermediate'>Playing With NPM</option>
                    <option value='Master'>Interpreted Language Interpreter</option>
                </select> <br>
                <label for='csharpSelect'>C#:</label> <br>
                <select name='C#' id='csharpSelect' required> 
                    <option value='Basic'>Learning Basics</option>
                    <option value='Intermediate'>C# Is Just Microsoft Java</option>
                    <option value='Master'>I Dream In Interfaces</option>
                </select> <br>
                <label for='glslSelect'>GLSL:</label> <br>
                <select name='GLSL' id='glslSelect' required> 
                    <option value='Basic'>Linear Algebra Is Scary</option>
                    <option value='Intermediate'>Linear Algebra Is Slightly Less Scary</option>
                    <option value='Master'>I Understand Tensors</option>
                </select> <br>
                <input type='submit' value='submit' />
              </form>
            ";

            return Content(html, "text/html");
        }
    }
}
