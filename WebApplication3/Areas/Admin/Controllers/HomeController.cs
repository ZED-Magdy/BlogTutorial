using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models;

namespace WebApplication3.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly DBContext context;

        public HomeController(DBContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {

            return View(context.Posts);
        }

        public IActionResult Create()
        {
            
            ViewData["Categories"] = new SelectList(context.Categories, "Id", "Name");
            return View();
        }

        public IActionResult Store(PostRequest request)
        {
            context.Posts.Add(new Post
            {
                Id = 4,
                Title = request.Title,
                Excerpt = request.Excerpt,
                Content = request.Content,
                Category = context.Categories.FirstOrDefault(c => c.Id == request.CategoryId),
                Owner = context.Users.First()
            });
            return Redirect(nameof(Index));
        }
    }
}
