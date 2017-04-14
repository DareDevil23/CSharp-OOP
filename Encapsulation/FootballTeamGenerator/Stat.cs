using System;
namespace FootballTeamGenerator
{
    public class Stat
    {
        private const int MinLevel = 0;
        private const int MaxLevel = 100;
        private string name;
        private int level;

        public Stat(string name, int level)
        {
            this.Name = name;
            this.Level = level;
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("A name should not be empty.");
                }
                this.name = value;
            }
        }

        public int Level
        {
            get { return this.level; }
            private set
            {
                if (value < MinLevel || value > MaxLevel)
                {
                    throw new ArgumentOutOfRangeException($"{this.Name} should be between {MinLevel} and {MaxLevel}.");
                }
                this.level = value;
            }
        }
        
    }
}
