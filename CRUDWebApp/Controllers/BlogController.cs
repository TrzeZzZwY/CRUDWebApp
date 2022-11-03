using CRUDWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUDWebApp.Controllers
{
    public class BlogController : Controller
    {

        public static List<Post> posts = new List<Post>();
        public static int count = 0;
        public IActionResult Index()
        {
            return View(posts);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View("PostForm");
        }
        [HttpPost]
        public IActionResult Add(Post post,[FromForm(Name = "image")] IFormFile image)
        {
            //if(!ModelState.IsValid)
            //    return View("PostForm");

            if(image is not null)
            {
                post.Image = new byte[image.Length];
                image.OpenReadStream().Read(post.Image, 0, (int)image.Length);
            }
            post.Id = count++;

            posts.Add(post);
            return View("index",posts);
        }

    }
}
