using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMa.Data.Entities
{
    public class Post
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Active { get; set; }

        public virtual AppUser AppUser { get; set; }
        public virtual List<PostComment> PostComments { get; set; }
    }
}
