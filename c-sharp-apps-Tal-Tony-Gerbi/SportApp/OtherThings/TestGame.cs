using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_Tal_Tony_Gerbi.SportApp.OtherThings
{
    internal class TestGame
    {
        public static void DemoGame()
        {
            GeneralPlayer player1 = new GeneralPlayer();
            player1.SetScoreName("Messi");
            player1.ScoreField();

            BasketBallPlayer player2 = new BasketBallPlayer();
            player2.SetScoreName("Michael Jordan");
            player2.ScoreField();
            player2.Score3();
            player2.AddFoul();
            player2.AddFoul();
            player2.AddFoul();
            player2.AddFoul();
            player2.AddFoul();

            SoccerPlayer player3 = new SoccerPlayer();
            player3.SetScoreName("Cristiano Ronaldo");
            player3.SetDribblingRate(8);
            player3.SetRedCard(true);
            player3.AddFoul();

        }
    }
}
