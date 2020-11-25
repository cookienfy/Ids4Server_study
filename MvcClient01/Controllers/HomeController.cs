using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcClient01.Models;

namespace MvcClient01.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            string accessToken = HttpContext.GetTokenAsync("access_token").Result;
            string idToken = HttpContext.GetTokenAsync("id_token").Result;
            var claimsList = from c in User.Claims select new { c.Type, c.Value };
            return View();
        }

        public async Task<IActionResult> Privacy()
        {
            string accessToken = HttpContext.GetTokenAsync("access_token").Result;
            string idToken = HttpContext.GetTokenAsync("id_token").Result;
            var claimsList = from c in User.Claims select new { c.Type, c.Value };
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var content = await client.GetStringAsync("http://localhost:9101/api/values");

            ViewBag.Json = content;

            return View();
        }

        public IActionResult SignOut()
        {
            return SignOut("Cookies", "oidc");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
