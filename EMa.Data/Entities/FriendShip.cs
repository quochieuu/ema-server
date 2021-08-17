using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMa.Data.Entities
{
    public class FriendShip
    {
        public Guid Id { get; set; }
        public Guid SenderId { get; set; }
        public Guid ReceipId { get; set; }
        public bool Confirmed { get; set; }

        public virtual AppUser AppUser { get; set; }
    }
}
