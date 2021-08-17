using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMa.Data.Entities
{
    public class Notification
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid? UserId { get; set; }
        public string Type { get; set; }

        public virtual AppUser AppUser { get; set; }
    }
}
