using System;

namespace FootballTeamGenerator
{
    public class Player 
    {
        private string name;

        public Player(string name, Stat endurance, Stat sprint, Stat dribble, Stat passing, Stat shooting)
        {
            this.Name = name;
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;         
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("A name should not be empty.");
                }
                this.name = value;
            }
        }

        public Stat Endurance { get; set; }
        public Stat Sprint { get; set; }
        public Stat Dribble { get; set; }
        public Stat Passing { get; set; }
        public Stat Shooting { get; set; }

        public double SkillLevel
        {
            get
            {
                return this.CalculateSkillLevel();
            }
        }

        private double CalculateSkillLevel()
        {
            double sum = this.Endurance.Level + this.Sprint.Level + this.Dribble.Level + this.Passing.Level + this.Shooting.Level;
            return Math.Round(sum / 5.0, 0);
        }
    }
}