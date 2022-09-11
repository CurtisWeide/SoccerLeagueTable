using System;
using System.IO;
using System.Text.RegularExpressions;

namespace SoccerLeagueTable
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] soccerArray = File.ReadAllLines("football.dat");

            int teamNameCol = 7;
            int forCol = 43;
            int againstCol = 50;
            string teamName = "";
            double? teamDiff;
            double forTotal;
            double againstTotal;
            double? currentPointsDiff = null;


            for (int i = 1; i < soccerArray.Length - 1; i++)
            {

                if(Regex.Match(soccerArray[i].Substring(forCol, 2), @"^\-+$").Success)
                {
                    continue;
                }

                forTotal = Convert.ToDouble(soccerArray[i].Substring(forCol, 2));
                againstTotal = Convert.ToDouble(soccerArray[i].Substring(againstCol, 2));
                teamDiff = forTotal - againstTotal;
                if (teamDiff < 0)
                {
                    teamDiff = teamDiff * -1;
                }

                if (currentPointsDiff == null || teamDiff < currentPointsDiff)
                {
                    currentPointsDiff = teamDiff;
                    teamName = soccerArray[i].Substring(teamNameCol, 14);
                }
                
            }

            Console.WriteLine("The team with the fewest points differential was: " + teamName);
            Console.ReadLine();
        }
    }
}
