using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMa.Data.Entities
{
    public class Blog
    {
        public Guid Id { get; set; }
        public Guid PostBy { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int ViewCount { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Thumbnail { get; set; }

        public virtual AppUser AppUser { get; set; }
    }
}
