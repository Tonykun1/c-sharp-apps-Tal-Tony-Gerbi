using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_Tal_Tony_Gerbi.SportApp
{
    public class Team
    {
        private string name;
        private string city;
        private string current_league;
        private int sum_Games;
        private int count_Games;
        private int winners;
        private int losing;
        private bool draw;
        private int points;
        private int goalsFor;
        private int goalAgainst;
        private int goalDifferential;

        public Team(string name, string city)
        {
            this.name = name;
            this.city = city;
        }
        public string GetName()
        {
            return name;
        }
        public void setName(string name)
        {
            this.name=name;
        }
        public string GetCity()
        {
            return city;
        }

        public void setCity(string city)
        {
            this.city = city;
        }
        public int GetPoints()
        {
            return points;
        }
        public void setPoints(int points)
        {
            this.points = points;
        }
        public string GetCurrentLeague()
        {
            return current_league;
        }
        public void setCurrentLeague(string CurrentLeague)
        {
            this.current_league = CurrentLeague;
        }
    }

}
