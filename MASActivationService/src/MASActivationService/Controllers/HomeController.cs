using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;


namespace MASActivationService.Controllers
{
    public class HomeController : Controller
    {
        // GET: /<controller>/

        public string Index()
        {
            return "This is my default action...";
        }
        public string Welcome(string name, int numTimes = 1)
        {
            return HtmlEncoder.Default.Encode($"Hello {name}, NumTimes is: {numTimes}");
        }
    }
}
