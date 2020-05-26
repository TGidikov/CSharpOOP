using System;

namespace PlayersAndMonsters
{
    public abstract class Hero
    {
        private const int HERO_MIN_LVL = 0;
        private string username;
        private int level;

        public Hero(string username, int level)
        {
            this.Username = username;
            this.Level = level;
        }
        public string Username
        {
            get
            {
                return this.username;
            }
            private set
            {
               if (string.IsNullOrWhiteSpace(value))
               {
                   throw new ArgumentException("Username cannot be null or whitespace !");
               }

                this.username = value;
            }
        }


        public int Level
        {
            get
            {
                return this.level;
            }
            private set

            {
                if (value<HERO_MIN_LVL)
                {
                    throw new ArgumentException("Level can be only positive number!");
                }
                this.level = value;
            }

        }
        public override string ToString()
        {
            return $"Type: {this.GetType().Name} Username: {this.Username} Level: {this.Level}";
        }

    }
}
