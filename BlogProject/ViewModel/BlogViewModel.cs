using BlogProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.ViewModel
{
    public class BlogViewModel
    {
        public Post Post { get; set; }
        public List<string> CategoryList { get; set; }
        public string Category { get; set; }

    }
}
