using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_Tal_Tony_Gerbi.SportApp
{
    public class Game
    {
        private Team team1;
        private Team team2;
        private int goalTeam1;
        private int goalTeam2;
        private bool gameIsActive;
        private string time=null;
        public Game(Team team1, Team team2, int goalTeam1, int goalTeam2, bool gameIsActive, string time)
        {
            this.team1 = team1;
            this.team2 = team2;
            this.goalTeam1 = 0;
            this.goalTeam2 = 0;
            this.time = time;
            this.gameIsActive = true;
        }
    }
}
