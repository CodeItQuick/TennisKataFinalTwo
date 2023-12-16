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
            if (p1point == p2point && p1point < 3)
            {
                score = ((PointToString)p1point) +  "-All";
            }

            if (p1point > 0 && p2point == 0)
            {
                score = ((PointToString)p1point) + "-" + ((PointToString)p2point);
            }

            if (p2point > 0 && p1point == 0)
            {
                score = ((PointToString)p1point) + "-" + ((PointToString)p2point);
            }

            if (p1point > p2point && p1point < 4)
            {
                score = (PointToString)p1point + "-" + (PointToString)p2point;
            }

            if (p2point > p1point && p2point < 4)
            {
                score = (PointToString)p1point + "-" + (PointToString)p2point;
            }

            if (p1point == p2point && p1point > 2)
                score = PointToString.Deuce.ToString();
            if (p1point > p2point && p2point >= 3)
            {
                score = "Advantage player1";
            }

            if (p2point > p1point && p1point >= 3)
            {
                score = "Advantage player2";
            }

            if (p1point >= 4 && p2point >= 0 && (p1point - p2point) >= 2)
            {
                score = "Win for player1";
            }
            if (p2point >= 4 && p1point >= 0 && (p2point - p1point) >= 2)
            {
                score = "Win for player2";
            }
            return score;
        }

        private void P1Score()
        {
            p1point++;
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

