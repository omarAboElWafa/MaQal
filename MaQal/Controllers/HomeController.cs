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

    }
}
