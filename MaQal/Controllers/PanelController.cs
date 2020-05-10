using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaQal.Data.Repository;
using MaQal.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MaQal.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PanelController : Controller
    {
        private IRepository _repos;

        public PanelController(IRepository repo)
        {
            _repos = repo;
        }
        public IActionResult Index()
        {
            var posts = _repos.GetAllPosts();
            return View(posts);
        }
 

        public IActionResult Edit(int? id)
        {
            if (id == null)
                return View(new Post());
            else
            {
                var post = _repos.GetPost((int)id);
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
