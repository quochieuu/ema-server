using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMa.Data.Entities
{
    public class FriendList
    {
        public Guid Id { get; set; }
        public Guid FriendId { get; set; }
        public Guid UserId { get; set; }

        public virtual AppUser AppUser { get; set; }
        public virtual FriendShip FriendShip { get; set; }
    }
}
