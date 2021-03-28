using BlogProject.Helpers;
using BlogProject.IRepositories;
using BlogProject.Models;
using BlogProject.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Controllers
{
    public class BlogController : Controller
    {
        private readonly IGetDataRepository getDataRepository;
        public BlogController(IGetDataRepository getDataRepository)
        {
            //this.signInManager = signInManager;
            this.getDataRepository = getDataRepository;

        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Edit(BlogViewModel blog)
        {
            var categories = getDataRepository.GetAllCategories();
            categories.Sort();
            blog.CategoryList = categories.ToList();
            this.ViewData[Constants.AllCats] = categories;
            return View(blog);
        }
        [HttpPost]
        public IActionResult UpdatePost(BlogViewModel blog)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(nameof(Edit), blog);
            }
            //var user = _iloginProvider.GetLoggedInUserData(HttpContext);
            blog.Post.CreatedBy = 1;
            getDataRepository.SaveBlog(blog);
            return View(blog);
        }
    }
}
