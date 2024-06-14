using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_Tal_Tony_Gerbi.SportApp
{
    public class Season
    {
        private int year;
        private string sportType;
        private string league;
        private Round rounds_Amount;
        private Round next_Rounds;
        private Team[] teams;
        private int numberOfTeam;
        private bool isActive;

        public Season(int year, string sportType, string leagueType, Round rounds_Amount, Round next_Rounds, Team[] teams, int numberOfTeam, bool isActive)
        {
            this.year = year;
            this.sportType = sportType;
            this.league = leagueType;
            this.rounds_Amount = rounds_Amount;
            this.next_Rounds = next_Rounds;
            this.numberOfTeam = numberOfTeam;
            this.teams=new Team[this.numberOfTeam];
            this.isActive = isActive;
        }
        public Season(int year, string sportType, string league, Team[] teams)
        {
            this.year = year;
            this.sportType = sportType;
            this.league = league;
            this.teams = teams;
        }
        public void setTeam(Team[] team)
        {
            this.teams = team;
        }
        public  void  DisplayTable()
        {
            for(int i = 0; i < this.teams.Length; i++)
            {
                Console.WriteLine($"Team {i+1}: {this.teams[i].GetName()} | Point: {this.teams[i].GetPoints()} ");
            }
            
        }
    }
}
