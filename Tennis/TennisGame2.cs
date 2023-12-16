using System;
using System.Collections.Generic;

namespace Tennis
{
    public enum PointToString
    {
        Love,
        Fifteen,
        Thirty,
        Forty,
        All,
        Deuce
    }

public class TennisGame2 : ITennisGame
    {
        private int p1point;
        private int p2point;

        private string p1res = "";
        private string p2res = "";
        private string player1Name;
        private string player2Name;

        public TennisGame2(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            p1point = 0;
            this.player2Name = player2Name;
        }

        public string GetScore()
        {
            var score = "";
            var pointDifference = Math.Abs(p1point - p2point);
            var highestPoint = Math.Max(p1point, p2point);
            var winningPlayer = (p1point > p2point ? "player1" : "player2");
            if (pointDifference > 0 && highestPoint < 4)
            {
                score = (PointToString)p1point + "-" + (PointToString)p2point;
            }
            if (pointDifference == 0 && highestPoint < 4)
            {
                score = (PointToString)p1point +  "-All";
            }
            if (pointDifference == 0 && highestPoint > 2)
            {
                score = PointToString.Deuce.ToString();
            }
            if (pointDifference == 1 && highestPoint > 3)
            {
                score = "Advantage " + winningPlayer;
            }
            if (pointDifference > 1 && highestPoint > 3)
            {
                score = "Win for " + winningPlayer;
            }
            return score;
        }

        public void WonPoint(string player)
        {
            if (player == "player1")
                p1point++;
            else
                p2point++;
        }

    }
}

