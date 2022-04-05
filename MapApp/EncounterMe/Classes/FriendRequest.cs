using System;


namespace EncounterMe
{
    public class FriendRequest
    {
        public string Id { get; set; }
        //needed for relationship auto-configuration
        public string UserId { get; set; } //request sender

        public User User { get; set; } //request sender

        public string ReceiverId { get; set; }

        public DateTime TimeSent { get; set; }
    }
}
