using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Models
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }
        public string Title { get; set; }
        public byte[] Photo { get; set; }
        public string Content { get; set; }
        public DateTime LastModified { get; set; } = DateTime.UtcNow;
        public DateTime PubDate { get; set; } = DateTime.UtcNow;
        public int CreatedBy { get; set; }
        [ForeignKey("CreatedBy")]
        public virtual User User { get; set; }
        public virtual ICollection<PostCategory> PostCategories { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }

    }
}
