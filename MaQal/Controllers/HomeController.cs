using MaQal.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaQal.Data;
using MaQal.Data.Repository;

namespace MaQal.Home
{
    public class HomeController : Controller
    {
        private IRepository _repos;

        public HomeController(IRepository repos)
        {
            _repos = repos;
        }


        public IActionResult Index()
        {
            var posts = _repos.GetAllPosts();
            return View(posts);
        }
        public IActionResult Post(int id)
        {
            var post = _repos.GetPost(id);
            return View(post);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
                return View(new Post());
            else
            {
                var post = _repos.GetPost((int) id);
                return View(post);
            }

        }

        [HttpPost]
        public async Task<IActionResult> Edit(Post post)
        {
            if (post.Id > 0)
            {
                _repos.UpdatePost(post);
            }
            else
            {
                _repos.AddPost(post);
            }

            if (await _repos.SaveChangesAsync())
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(post);
            }
        }

        public async Task<IActionResult> Remove(int id)
        {
            _repos.RemovePost(id);
            await _repos.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
