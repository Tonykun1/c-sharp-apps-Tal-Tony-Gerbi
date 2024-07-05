using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_Tal_Tony_Gerbi.SportApp.OtherThings
{
    public class GeneralPlayer
    {
        private int points=0;
        private string scoreName="";
        private string name="";
        private int assists=0;
        private int fouls = 0;
        private bool outOfGame=false;

        public GeneralPlayer(string name,string scoreName)
        {
            this.scoreName = scoreName;
            this.name = name;
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
        public string GetName()
        {
            return name;
        }
        public void SetName(string name)
        {
            this.name = name;
        }
        public virtual void ScoreField()
        {
            this.points++;
            DisplayScore();
        }
        public void DisplayScore()
        {
            Console.WriteLine($"{this.name} scored a {this.scoreName}!");
        }
        public virtual void AddFoul()
        {
            this.fouls++;
        }
        public override string ToString()
        {
            return $"name {this.scoreName}, assists {this.assists}, points {this.points},fouls {this.fouls} ,outOfGame {this.outOfGame}" ;
        }
    }
    public class BasketBallPlayer : GeneralPlayer
    {
        private int dunks = 0;
        private int threeShots = 0;
        private int rebounds = 0;

        public BasketBallPlayer(string name,string scoreName) : base(name,scoreName)
        {

        }
        public BasketBallPlayer(string name, string scoreName,int dunks,int threeShots,int rebounds) : base(name, scoreName)
        {
            this.dunks = dunks;
            this.threeShots = threeShots;
            this.rebounds = rebounds;
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

            SetPoints(base.GetPoints()+2);
            DisplayScore();
        }

        public override void AddFoul()
        {
            base.AddFoul();
            if (GetFouls() == 5)
            {
                SetOutOfGame(true);
                Console.WriteLine($"{GetName()} is out of the game");
            }
        }

        public void Score3()
        {
            SetPoints(base.GetPoints() + 3);
            this.threeShots++;
            DisplayScore();
        }
        public override string ToString()
        {
            return $" {base.ToString()} ,dunks {dunks}, threeShots {threeShots},  rebounds {rebounds}";
        }
    }
    public class SoccerPlayer : GeneralPlayer
    {
        private bool redCard=false;
        private int penalties=0;
        private int dribblingRate=0;

        public SoccerPlayer(string name,string scoreName) : base(name,scoreName)
        {

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
            base.AddFoul();
            if (this.redCard)
            {
                SetOutOfGame(true);
                Console.WriteLine($"{GetName()} is out of the game due to a red card.");
            }
        }
        public void SetRedCard(bool redCard)
        {
            this.redCard = redCard;
            if (redCard)
            {
                SetOutOfGame(true);
                Console.WriteLine($"{GetName()} received a red card and is out of the game.");
            }
        }
        public override string ToString()
        {
            return $" {base.ToString()} ,redCard {redCard}, penalties {penalties},  dribblingRate {dribblingRate}";
        }
    }
}
