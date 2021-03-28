using BlogProject.IRepositories;
using BlogProject.Models;
using BlogProject.ViewModel;
using System;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace BlogProject.Repositories
{
    public class UserRepository : IUserRepository
    {
        private BlogDBContext dBContext;
        public UserRepository(BlogDBContext dbContext)
        {
            this.dBContext = dbContext;
        }

        public string Encryptpass(string password)
        {
            string msg = "";
            byte[] encode = new byte[password.Length];
            encode = Encoding.UTF8.GetBytes(password);
            msg = Convert.ToBase64String(encode);
            return msg;
        }
        public ActionResult SaveUser(LoginViewModel model)
        {
            if (model != null)
            {
                User user = new User();
                user.Username = model.Username;
                user.Password =Encryptpass(model.Password);
                user.CreatedOn = DateTime.Now;
                dBContext.Users.Add(user);
                dBContext.SaveChanges();

                return new JsonResult
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = new
                    {
                        success = true
                    }
                };
            }else
            {
                return new JsonResult
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = new
                    {
                        success = false
                    }
                };
            }
        } 
        public bool GetUserByUsername (string username)
        {
            var user = dBContext.Users.Single(u => u.Username.Equals(username));
            if (user != null){
                return true;
            }
            else 
            { return false; }
        }
    }
}
