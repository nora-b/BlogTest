using BlogProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BlogProject.IRepositories
{
   public interface IUserRepository
    {
        string Encryptpass(string password);
        ActionResult SaveUser(LoginViewModel model);
        bool GetUserByUsername(string username);
    }
}
