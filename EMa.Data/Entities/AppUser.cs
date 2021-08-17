using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMa.Data.Entities
{
    public class AppUser : IdentityUser<Guid>
    {
        public Guid Id { get; set; }
        public string ParentName { get; set; }
        public DateTimeOffset ParentAge { get; set; }
        public string ChildName { get; set; }
        public DateTimeOffset ChildBirth { get; set; }
        public bool ChildGender { get; set; } // 0 Nam 1 Nu
        public string IdentityCard { get; set; }
        public string Address { get; set; }
        public string UrlAvatar { get; set; }
    }
}
