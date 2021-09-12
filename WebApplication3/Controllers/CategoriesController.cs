using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly DBContext context;

        public CategoriesController(DBContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Details(int id)
        {
            var category = context.Categories.FirstOrDefault(p => p.Id == id);
            return View(category.Posts);
        }
    }
}
