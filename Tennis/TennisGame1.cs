using System;

namespace Tennis
{
    public class TennisGame1 : ITennisGame
    {
        private int m_score1 = 0;
        private int m_score2 = 0;
        private string player1Name;
        private string player2Name;

        private enum GameScore
        {
            Love,
            Fifteen,
            Thirty,
            Forty,
            Deuce
        }
        private enum GameScoreTied
        {
            Love,
            Fifteen,
            Thirty
        }

        public TennisGame1(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
                m_score1 += 1;
            else
                m_score2 += 1;
        }

        public string GetScore()
        {
            if (m_score1 < 4 && m_score2 < 4 && m_score1 != m_score2)
            {
                return PreGamePoint();
            }
            if (m_score1 == m_score2)
            {
                return TieGame();
            }

            return GamePoint();
            

        }

        private string TieGame()
        {
            var tryParseTwo = Enum.TryParse<GameScoreTied>(((GameScore)m_score1).ToString(), out var resultTwo);
            if (tryParseTwo)
            {
                return resultTwo + "-All";
            }

            return GameScore.Deuce.ToString();
        }

        private string GamePoint()
        {
            string winningPlayer;
            if (m_score1 - m_score2 > 0)
            {
                winningPlayer = "player1";
            }
            else
            {
                winningPlayer = "player2";
            }

            if (Math.Abs(m_score1 - m_score2) == 1)
            {
                return "Advantage " + winningPlayer;
            }

            return "Win for " + winningPlayer;
        }

        private string PreGamePoint()
        {
            string score = "";
            var tryParse = Enum.TryParse<GameScore>(((GameScore)m_score1).ToString(), out var result);
            if (tryParse)
            {
                score += result;
            }

            score += "-";

            var tryParseScore = Enum.TryParse<GameScore>(((GameScore)m_score2).ToString(), out var resultScore);
            if (tryParseScore)
            {
                score += resultScore;
            }

            return score;
        }
    }
}

