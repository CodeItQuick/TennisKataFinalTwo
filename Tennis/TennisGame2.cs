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
        private int _p1Point;
        private int _p2Point;

        private readonly string _player1Name;
        private readonly string _player2Name;

        public TennisGame2(string player1Name, string player2Name)
        {
            _player1Name = player1Name;
            _player2Name = player2Name;
            _p1Point = 0;
        }

        public string GetScore()
        {
            var score = "";
            var pointDifference = Math.Abs(_p1Point - _p2Point);
            var highestPoint = Math.Max(_p1Point, _p2Point);
            var winningPlayer = _p1Point > _p2Point ? _player1Name : _player2Name;
            if (pointDifference == 0 && highestPoint > 2)
            {
                return PointToString.Deuce.ToString();
            }
            if (pointDifference > 0 && highestPoint < 4)
            {
                return (PointToString)_p1Point + "-" + (PointToString)_p2Point;
            }
            if (pointDifference == 0 && highestPoint < 4)
            {
                return (PointToString)_p1Point +  "-All";
            }
            if (pointDifference == 1 && highestPoint > 3)
            {
                return "Advantage " + winningPlayer;
            }
            if (pointDifference > 1 && highestPoint > 3)
            {
                return "Win for " + winningPlayer;
            }
            return score;
        }

        public void WonPoint(string player)
        {
            if (player == "player1")
                _p1Point++;
            else
                _p2Point++;
        }

    }
}

