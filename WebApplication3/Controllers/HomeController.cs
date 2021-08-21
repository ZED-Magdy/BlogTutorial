using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        private DBContext context { get; set; }
        public HomeController()
        {
            context = new DBContext();
        }
        public IActionResult Index([FromQuery]int page = 1)
        {
            var perPage = 20;
            var posts = context.Posts.Skip(((page-1) * perPage)).Take(perPage).ToList();
            
            return View(posts);
        }

        [HttpGet("/posts/{id}")]
        public IActionResult Details(int id)
        {
            var post = context.Posts.Where(post => post.Id == id).FirstOrDefault();
            return View(post);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
