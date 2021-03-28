using BlogProject.IRepositories;
using BlogProject.Models;
using BlogProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BlogProject.Repositories
{
    public class GetDataRepository : IGetDataRepository
    {
        private BlogDBContext dBContext;
        public GetDataRepository(BlogDBContext dbContext)
        {
            this.dBContext = dbContext;
        }
        public List<string> GetAllCategories()
        {
            var result = dBContext.Categories.Select(post => post.CategoryName).ToList();
                //.Select(a=>a.ToString().ToLower());
            return result;
        }
        public ActionResult SaveBlog(BlogViewModel blog)
        {
            if (blog.Post.PostId == 0)
            {
                Post post = new Post();
                post.Title = blog.Post.Title;
                post.Content = blog.Post.Content;
                post.Photo = blog.Post.Photo;
                post.LastModified = DateTime.Now;
                post.PubDate = DateTime.Now;
                post.CreatedBy = blog.Post.CreatedBy;
               
                dBContext.Posts.Add(post);
                dBContext.SaveChanges();
                
                var postId = post.PostId;
                //ruajtja e kategorive per postim
                PostCategory postCategory = new PostCategory();
                foreach (var category in blog.CategoryList)
                {
                    postCategory.PostId = postId;
                    var categoryId = dBContext.Categories.Where(a => a.CategoryName == category).Select(a => a.CategoryId).Single();
                    postCategory.CategoryId = categoryId;
                }

            }
            return new JsonResult
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = new
                {
                    success = true
                }
            };
        }
    }
}
