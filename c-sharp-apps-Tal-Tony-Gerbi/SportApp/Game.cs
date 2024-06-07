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
        private string time= null;
        public Game(Team team1, Team team2, int goalTeam1, int goalTeam2, bool gameIsActive, string time)
        {
            this.team1 = team1;
            this.team2 = team2;
            this.goalTeam1 = 0;
            this.goalTeam2 = 0;
            this.time = time;
            this.gameIsActive = true;
        }
        public void ScoreGoal(Team team)
        {
            if (this.gameIsActive)
            {
                if (team == this.team1)
                {
                    this.goalTeam1++;
                }
                else if (team == this.team2)
                {
                    this.goalTeam2++;
                }
                Console.WriteLine($"{team.GetName()} scored a goal!");
            }
            else
            {
                Console.WriteLine("The game has already finished. No more goals can be scored.");
            }
        }

        public void FinishGame()
        {
            this.gameIsActive = false;

            Console.WriteLine($"The game has ended. Final scores:");
            Console.WriteLine($"{team1.GetName()}: {goalTeam1}");
            Console.WriteLine($"{team2.GetName()}: {goalTeam2}");

            if (this.goalTeam1 > this.goalTeam2)
            {
                Console.WriteLine($"The winner is {team1.GetName()}");
                team1.setPoints(3);
                team2.setPoints(0);
            }
            else if (this.goalTeam2 > this.goalTeam1)
            {
                Console.WriteLine($"The winner is {team2.GetName()}");
                team1.setPoints(0);
                team2.setPoints(3);
            }
            else
            {
                Console.WriteLine("The game ended in a draw.");
                team1.setPoints(1);
                team2.setPoints(1);
            }
        }
    }
}
