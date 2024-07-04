using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_Tal_Tony_Gerbi.SportApp.OtherThings
{
    public class GeneralPlayer
    {
        protected int points;
        protected string scoreName;
        protected int assists;
        protected int fouls;
        protected bool outOfGame;

        public GeneralPlayer()
        {
            this.points = 0;
            this.scoreName = "";
            this.assists = 0;
            this.fouls = 0;
            this.outOfGame = false;
        }
        public int GetPoints()
        {
            return points;
        }
        public void SetPoints(int points)
        {
            this.points = points;
        }
        public string GetScoreName()
        {
            return scoreName;
        }
        public void SetScoreName(string ScoreName)
        {
            this.scoreName = ScoreName;
        }
        public int GetAssists()
        {
            return assists;
        }
        public void SetAssists(int assists)
        {
            this.assists = assists;
        }
        public int GetFouls()
        {
            return fouls;
        }
        public void SetFouls(int fouls)
        {
            this.fouls = fouls;
        }
        public bool GetOutOfGame()
        {
            return outOfGame;
        }
        public void SetOutOfGame(bool outOfGame)
        {
            this.outOfGame = outOfGame;
        }
        public virtual void ScoreField()
        {
            this.points++;
            DisplayScore();
        }
        public void DisplayScore()
        {
            Console.WriteLine($"{this.scoreName} scored a GOAL");
        }
        public virtual void AddFoul()
        {
            this.fouls++;
        }
    }
    public class BasketBallPlayer : GeneralPlayer
    {
        private int dunks;
        private int threeShots;
        private int rebounds;

        public BasketBallPlayer() : base()
        {
            this.dunks = 0;
            this.threeShots = 0;
            this.rebounds = 0;
        }
        public int GetThreeShots()
        {
            return threeShots;
        }
        public int GetDunks()
        {
            return dunks;
        }
        public void SetDunks(int dunks)
        {
            this.dunks = dunks;
        }
        public void SetThreeShots(int threeShots)
        {
            this.threeShots = threeShots;
        }
        public void SetRebounds(int rebounds)
        {
            this.rebounds = rebounds;
        }
        public int GetRebounds()
        {
            return rebounds;
        }
        public override void ScoreField()
        {
            this.points += 2;
            Console.WriteLine($"{this.scoreName} scored a basket");
        }

        public override void AddFoul()
        {
            this.fouls++;
            if (this.fouls >= 5)
            {
                this.outOfGame = true;
                Console.WriteLine($"{this.scoreName} is out of the game");
            }
        }

        public void Score3()
        {
            this.points += 3;
            this.threeShots++;
            Console.WriteLine($"{this.scoreName} scored a three-pointer");
        }
    }
    public class SoccerPlayer : GeneralPlayer
    {
        private bool redCard;
        private int penalties;
        private int dribblingRate;

        public SoccerPlayer() : base()
        {
            this.redCard = false;
            this.penalties = 0;
            this.dribblingRate = 0;
        }
        public void SetDribblingRate(int dribblingRate)
        {
            if (this.dribblingRate < 1 || this.dribblingRate > 10)
            {
                this.dribblingRate= dribblingRate;
                Console.WriteLine("Dribbling rate must be between 1 and 10.");
                Console.WriteLine($"the number of dribblingRate is {this.dribblingRate}");
            }
            else
            {
                Console.WriteLine("Sorry, ERROR");
            }
        }
        public override void AddFoul()
        {
            this.fouls++;
            if (this.redCard)
            {
                this.outOfGame = true;
                Console.WriteLine($"{this.scoreName} is out of the game due to a red card.");
            }
        }
        public void SetRedCard(bool redCard)
        {
            this.redCard = redCard;
            if (redCard)
            {
                this.outOfGame = true;
                Console.WriteLine($"{this.scoreName} received a red card and is out of the game.");
            }
        }
    }
}
