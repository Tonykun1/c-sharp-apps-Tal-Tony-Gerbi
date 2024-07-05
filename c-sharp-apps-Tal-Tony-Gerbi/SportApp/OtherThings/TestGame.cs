﻿using System;
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
            GeneralPlayer player1 = new GeneralPlayer("MESSI","GOAL");
            player1.ScoreField();
            Console.WriteLine(player1);
            Console.WriteLine("");
            BasketBallPlayer player2 = new BasketBallPlayer("Michael Jordan","Basket");
            player2.ScoreField();
            player2.Score3();
            player2.AddFoul();
            player2.AddFoul();
            player2.AddFoul();
            player2.AddFoul();
            player2.AddFoul();
            Console.WriteLine(player2);
            Console.WriteLine("");
            SoccerPlayer player3 = new SoccerPlayer("Cristiano Ronaldo","Goal");
            player3.SetDribblingRate(8);
            player3.AddFoul();
            player3.SetRedCard(true);
            Console.WriteLine(player3);
        }
    }
}
