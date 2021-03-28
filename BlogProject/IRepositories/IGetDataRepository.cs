﻿using BlogProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BlogProject.IRepositories
{
   public interface IGetDataRepository
    {
        List<string> GetAllCategories();
        ActionResult SaveBlog(BlogViewModel blog);
    }
}
