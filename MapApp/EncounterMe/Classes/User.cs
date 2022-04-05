﻿using System;
using System.Text;
using System.Security.Cryptography;
using System.Linq;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace EncounterMe
{
    public enum AccessLevel
    {
        User, Admin
    }

    [Serializable]
    public class User : Entity, ISerializable
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public byte[] Hashpassword { get; set; }
        public AccessLevel AccessLevel { get; set; }
        public int LevelPoints { get; set; }
        public int AchievementNum { get; set; }
        public int FoundLocationNum { get; set; }

        public string Password { get; set; } = string.Empty;

        //needed for relationship auto-configuration
        public List<Friend> Friends { get; set; }
        public List<FriendRequest> FriendRequests { get; set; } 

        public User() 
        {
            Name = "empty";
            Email = "empty";
            Hashpassword = HashPassword("empty");
        }

        public User(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Hashpassword = HashPassword(password);
            AccessLevel = AccessLevel.User;
            Password= password;
        }

        public User(SerializationInfo info, StreamingContext context)
        {
            Name = (string)info.GetValue("Username", typeof(string));
            Email = (string)info.GetValue("Email", typeof(string));
            Hashpassword = (byte[])info.GetValue("Password", typeof(byte[]));
            AccessLevel = (AccessLevel)info.GetValue("Password", typeof(AccessLevel));
        }

        private byte[] HashPassword(string password)
        {
            var provider = new SHA256CryptoServiceProvider();
            var encoding = new UnicodeEncoding();
            return provider.ComputeHash(encoding.GetBytes(password));
        }

        public bool CompareHashPassword(string password)
        {
            return Hashpassword.SequenceEqual(HashPassword(password));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Username", Name);
            info.AddValue("Email", Email);
            info.AddValue("Password", Hashpassword);
            info.AddValue("AccessLevel", AccessLevel);
        }

        public void CalculateLevel(out int level, out float completionPerc)
        {
            int expPoints = LevelPoints;
            level = 0;
            completionPerc = 0;
            int levelOne = 100, exp = levelOne;

            while (expPoints - exp > 0)
            {
                expPoints -= exp;
                ++level;
                exp = exp + (int)(exp * 0.1);
            }
            completionPerc = (float)(expPoints) / (float)(exp);
        }
    }

    public class AccessRights
    {
        public AccessLevel AccessLevel { get; set; }
        public String AccessName { get; set; }

        public AccessRights()
        {
            AccessName = "";
        }
    }
}
