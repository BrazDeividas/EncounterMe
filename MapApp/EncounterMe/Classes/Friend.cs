using System;
using System.Collections.Generic;
using System.Text;

namespace EncounterMe
{
    public class Friend : Entity
    {
        public int FriendId { get; set; }

        //needed for relationship auto-configuration
        public int UserId { get; set; }
        public User User { get; set; }

    }
}
