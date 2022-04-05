using System;
using System.Collections.Generic;
using System.Text;

namespace EncounterMe
{ 
    public class FriendDto
    {
        public int Id { get; set; } 

        public string Name { get; set; }

        public int LevelPoints { get; set; }

        public FriendDto(int id, string name, int levelPoints)
        {
            Id = id;
            Name = name;
            LevelPoints = levelPoints;
        }

    }
}
