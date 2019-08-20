using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using TezzaBizSolution.Lib;
using TezzaBizSolution.Web.Models;

namespace TezzaBizSolution.Web.Controllers
{
    
    public class HomeController : Controller
    {
        private HereAPI hereAPI;

        public HomeController(IOptions<HereAPI> hereAPIOptions)
        {
            hereAPI = hereAPIOptions.Value;
        }

        public IActionResult Index()
        {
            ViewData["AppID"] = hereAPI.AppID;
            ViewData["AppCode"] = hereAPI.AppCode;
            ViewData["JavaScriptApiKey"] = hereAPI.JavaScriptApiKey;
            ViewData["ShowRoute"] = false;

            return View();
        }

        public IActionResult Privacy()
        {
            ViewData["ShowRoute"] = false;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            ViewData["ShowRoute"] = false;
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
