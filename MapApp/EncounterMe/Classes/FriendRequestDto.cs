using System;
using System.Collections.Generic;
using System.Text;

namespace EncounterMe
{ 
    public class FriendRequestDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int LevelPoints { get; set; }

        public DateTime TimeSent { get; set; }

        public FriendRequestDto(int id, string name, int levelPoints, DateTime timeSent)
        {
            Id = id;
            Name = name;
            LevelPoints = levelPoints;
            TimeSent = timeSent;
        }
    }
}
