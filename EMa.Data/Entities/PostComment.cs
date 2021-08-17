﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMa.Data.Entities
{
    public class PostComment
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid PostId { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual AppUser AppUser { get; set; }
        public virtual Post Post { get; set; }

    }
}
