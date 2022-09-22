using Microsoft.AspNetCore.Mvc;

namespace SkillsTracker.Controllers
{
    public class SkillsController : Controller
    {
        [Route("/skills")]
        public IActionResult Index()
        {
            return Content(@"
                <h1>Skills Tracker<h1>
                <h2>Coding skills to learn:<h2>
                <h3><ol><li>Python<li>JavaScript<li>C#<ol><h3>
                ", "text/html");
        }

        public IActionResult Form()
        {
            string html = @"
                <form method='post' action='/skills/form' >
                <label for='date'>Date:</label> <br> 
                <input type='date' name='date' id='date' /> <br>
                <label for='csharpSelect'>C#:</label> <br>
                <select name='csharp' id='csharpSelect'> 
                    <option value='learningBasics'>Learning basics</option>
                    <option value='makingApps'>Making apps</option>
                    <option value='masterCoder'>Master coder</option>
                </select> <br>
                <label for='javascriptSelect'>Javascript:</label> <br>
                <select name='javascript' id='javascriptSelect'> 
                    <option value='learningBasics'>Learning basics</option>
                    <option value='makingApps'>Making apps</option>
                    <option value='masterCoder'>Master coder</option>
                </select> <br>
                <label for='pythonSelect'>Python:</label> <br>
                <select name='python' id='pythonSelect'> 
                    <option value='learningBasics'>Learning basics</option>
                    <option value='makingApps'>Making apps</option>
                    <option value='masterCoder'>Master coder</option>
                </select> <br>
                <input type='submit' value='submit' />
            ";

            return Content(html, "text/html");
        }
    }
}
