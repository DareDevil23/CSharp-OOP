using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator
{
    public class Team
    {
        private string teamName;
        private double rating;

        public Team(string name)
        {
            this.TeamName = name;
            this.Rating = 0.0;
            this.Players = new Dictionary<string, Player>();         
        }
       
        public string TeamName
        {
            get { return this.teamName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("A name should not be empty.");
                }
                this.teamName = value;
            }
        }       
        
        public double Rating
        {
            get
            {
                return this.CalculateRating();
            }
           private set { this.rating = value; }
        }

        public Dictionary<string, Player> Players { get; set; }

        public void AddPlayer(Player player)
        {
            this.Players.Add(player.Name, player);
        }

        public void RemovePlayer(string playerName)
        {
            if (!this.Players.ContainsKey(playerName))
            {
                throw new InvalidOperationException($"Player {playerName} is not in {this.TeamName} team.");
            }
            this.Players.Remove(playerName);
        }

        public override string ToString()
        {
            return string.Format($"{this.TeamName} - {this.Rating}");
        }

        private double CalculateRating()
        {          
            return this.Players.Values.Count() == 0 ? 0 
                : this.Players.Values.Sum(pR => pR.SkillLevel) / this.Players.Values.Count();
        }
    }
}
