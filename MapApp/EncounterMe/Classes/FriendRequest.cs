using System;


namespace EncounterMe
{
    public class FriendRequest : Entity
    {
        //needed for relationship auto-configuration
        public int UserId { get; set; } //request sender

        public User? User { get; set; } //request sender

        public int ReceiverId { get; set; }

        public DateTime TimeSent { get; set; }
    }
}
