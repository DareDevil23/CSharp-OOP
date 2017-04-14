using System;
using System.Collections.Generic;

namespace FootballTeamGenerator
{
    class Program
    {
        static Dictionary<string,Team> teams = new Dictionary<string, Team>();

        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            while (!input.Equals("END"))
            {
                string[] tokens = input.Split(';');
                string comand = tokens[0];
                try
                {
                    ExecuteCommand(tokens, comand);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.ParamName);
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                
                input = Console.ReadLine();
            }
        }

        private static void ExecuteCommand(string[] tokens, string comand)
        {
            switch (comand)
            {
                case "Team":
                    string teamName = tokens[1];
                    Team team = new Team(teamName);
                    teams.Add(teamName, team);
                    break;
                case "Add":
                    AddPlayerToTeam(tokens);
                    break;
                case "Remove":
                    RemovePlayerFromTeam(tokens);
                    break;
                case "Rating":
                    ShowTeamRating(tokens);
                    break;
                default:
                    break;
            }
        }

        private static void RemovePlayerFromTeam(string[] tokens)
        {
            string team = tokens[1];
            string playerName = tokens[2];
            teams[team].RemovePlayer(playerName);           
        }

        private static void AddPlayerToTeam(string[] tokens)
        {
            string desiredTeam = tokens[1];
            if (!teams.ContainsKey(desiredTeam))
            {
                throw new InvalidOperationException($"Team {desiredTeam} does not exist.");
            }
            string playerName = tokens[2];
            Player player = new Player(
                                        playerName,
                                        new Stat("Endurance", int.Parse(tokens[3])),
                                        new Stat("Sprint", int.Parse(tokens[4])),
                                        new Stat("Dribble", int.Parse(tokens[5])),
                                        new Stat("Passing", int.Parse(tokens[6])),
                                        new Stat("Shooting", int.Parse(tokens[7]))
                                       );
            teams[desiredTeam].AddPlayer(player);
        }

        private static void ShowTeamRating(string[] tokens)
        {
            string teamName = tokens[1];
            if (!teams.ContainsKey(teamName))
            {
                Console.WriteLine($"Team {teamName} does not exist.");
                return;
            }

            Console.WriteLine(teams[teamName]);
        }
    }
}
