using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace c_sharp_apps_Tal_Tony_Gerbi.SportApp
{
    public class TestSportApp
    {

        public static void Test1()
        {

            Console.WriteLine("Test 1 - champions league mock");
            Season[] groups = CreateChampionsLeagueMock();
            Console.WriteLine();
            for (int i = 0; i < groups.Length; i++)
            {
                groups[i].DisplayTable();
                Console.WriteLine("");
            }

        }
        public static Season[] CreateChampionsLeagueMock()
        {
            Season[] groups = new Season[8];
            //יצריה של הקבוצה כל אחת בפנרד
            //קבוצה א
            Team bayern = new Team("Bayern", "Bayern");
            Team copenhagen = new Team("Copenhagen", "Copenhagen");
            Team galastray = new Team("Galastray", "Galastray");
            Team manUnited = new Team("Man United", "Manchester");
            //קבוצה ב
            Team arsenal = new Team("Arsenal", "London");
            Team psv = new Team("psv", "eindhoven");
            Team lens = new Team("Lens", "Lens");
            Team sevilla = new Team("Sevilla", "Sevilla");
            //קבוצה ג
            Team realMadrid = new Team(" Real Madrid", "madrid");
            Team napoli = new Team("Napoli", "Napoli");
            Team braja = new Team("Braja", "Braja");
            Team unionBerlin = new Team("Union Berlin", "Berlin");
            //קבוצה ד
            Team realSociedad = new Team("Real Sociedad", "Sebastián");
            Team inter = new Team("Inter", "Milan");
            Team benfica = new Team("benfica", "lisbon");
            Team sazlburg = new Team("salzburg", "salzburg");
            //קבוצה ה
            Team atleteco = new Team("Atletico Madrid", "Madrid");
            Team lazio = new Team("Lazio", "Roma");
            Team feyenoord = new Team("Feyenoord", "Rotterdam");
            Team celtic = new Team("Celtic", "Glasgow");
            //קבוצה ו
            Team dortmund = new Team("Dortmund ", "Dortmund");
            Team psg = new Team("PSG ", "Paris");
            Team aCMilan = new Team("AC Milan ", "Milan");
            Team newCastle = new Team("NewCastle ", "United Kingdom");
            //קבוצה ז
            Team manchesterCity = new Team("Manchester City ", "Manchester");
            Team rbLeipzig = new Team("RB Leipzig", "leipzig");
            Team youngBoys = new Team("Young Boys", "Bern");
            Team crvana = new Team("Crvena zvezda", "Belgrad");
            //קבוצה ח
            Team barcelona = new Team("Barcelona", "Barcelona");
            Team porto = new Team("Porto", "Porto");
            Team shakhtarDonetsk = new Team("Shakhtar Donetsk", "Donetsk");
            Team antwerpFc = new Team("AntwerpFc", "Antwerp");
            //יצרה של הקבוצות
            Team[] teams1 = { bayern, copenhagen, galastray, manUnited };
            Team[] teams2 = { arsenal, psv, lens, sevilla };
            Team[] teams3 = { realMadrid, napoli, braja, unionBerlin };
            Team[] teams4 = { realSociedad, inter, benfica, sazlburg };
            Team[] teams5 = { atleteco, lazio, feyenoord, celtic };
            Team[] teams6 = { dortmund, psg, aCMilan, newCastle };
            Team[] teams7 = { manchesterCity, rbLeipzig, youngBoys, crvana };
            Team[] teams8 = { barcelona, porto, shakhtarDonetsk, antwerpFc };
            //יצירה בתוך עונה של הקבוצות
            Season groupA = new Season(2024, "soccer", "Champoins - Group A", teams1);
            Season groupB = new Season(2024, "soccer", "Champoins - Group B", teams2);
            Season groupC = new Season(2024, "soccer", "Champoins - Group C", teams3);
            Season groupD = new Season(2024, "soccer", "Champoins - Group D", teams4);
            Season groupE = new Season(2024, "soccer", "Champoins - Group E", teams5);
            Season groupF = new Season(2024, "soccer", "Champoins - Group F", teams6);
            Season groupG = new Season(2024, "soccer", "Champoins - Group G", teams7);
            Season groupH = new Season(2024, "soccer", "Champoins - Group H", teams8);


            //הכנסת העונה למערך של העונות
            groups[0] = groupA;
            groups[1] = groupB;
            groups[2] = groupC;
            groups[3] = groupD;
            groups[4] = groupE;
            groups[5] = groupF;
            groups[6] = groupG;
            groups[7] = groupH;

            //הפעלה משחק בין הקבוצות
            Game firstGame = new Game(bayern, copenhagen, 0, 0, true, "00:00");
            //גול ראשון לקבוצה א
            firstGame.ScoreGoal(bayern);
            //גול ראשון לקבוצה ב
            firstGame.ScoreGoal(copenhagen);
            //סיום בתיקו 
            firstGame.FinishGame();
            return groups;



        }

    }
}
