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
        public HomeController(DBContext dbContext)
        {
            context = dbContext;
        }
        public IActionResult Index([FromQuery]int page = 1)
        {
            var perPage = 3;
            var posts = context.Posts
                .Skip((page - 1) * perPage)
                .Take(perPage)
                .ToList();


            ViewData["next_page"] = page + 1;
            return View(posts);
        }

        public IActionResult Create()
        {
            var postRequest = new PostRequest();
            return View(postRequest);
        }

        [HttpPost]
        public IActionResult Store([FromForm]PostRequest postRequest)
        {
            if(ModelState.IsValid)
            {
                context.Posts.Add(new Post
                {
                    Id = 4,
                    Title = postRequest.Title,
                    Excerpt = postRequest.Excerpt,
                    Content = postRequest.Content,
                    Owner = context.Users.FirstOrDefault()
                });
                
                return Redirect("/");
            }
            return View("Create", postRequest);
        }

        public IActionResult Edit([FromRoute] int id)
        {
            var post = context.Posts.Where(post => post.Id == id).FirstOrDefault();
            if(post == null)
            {
                return View("404");
            }
            var request = new PostRequest
            {
                Title = post.Title,
                Excerpt = post.Excerpt,
                Content = post.Content
            };
            return View(request);
        }
        [HttpPost]
        public IActionResult Edit([FromRoute]int id, [FromForm]PostRequest request)
        {
            var post = context.Posts.Where(post => post.Id == id).FirstOrDefault();
            if (post == null)
            {
                return View("404");
            }
            if(ModelState.IsValid)
            {
                post.Title = request.Title;
                post.Excerpt = request.Excerpt;
                post.Content = request.Content;
                return Redirect($"/posts/{post.Id}");
            }
            return View(request);

        }

        [HttpGet("/posts/{id}")]
        public IActionResult Details(int id)
        {
            var post = context.Posts.Where(post => post.Id == id).FirstOrDefault();
            if(post == null)
            {
                return View("404");
            }
            return View(post);
        }
        public IActionResult Delete([FromRoute]int id)
        {
            var post = context.Posts.Where(post => post.Id == id).FirstOrDefault();
            if (post == null)
            {
                return View("404");
            }
            return View(post);
        }
        [HttpPost]
        public IActionResult DeleteConfirmed([FromRoute]int id)
        {
            var post = context.Posts.Where(post => post.Id == id).FirstOrDefault();
            if (post == null)
            {
                return View("404");
            }
            context.Posts.Remove(post);
            return Redirect("/");
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
