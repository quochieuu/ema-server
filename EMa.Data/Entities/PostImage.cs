using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMa.Data.Entities
{
    public class PostImage
    {
        public Guid Id { get; set; }
        public Guid ImageId { get; set; }
        public Guid PostId { get; set; }

        public virtual Post Post { get; set; }
        public virtual Image Image { get; set; }
    }
}
