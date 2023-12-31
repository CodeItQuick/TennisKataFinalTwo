using System;

namespace Tennis
{
    public class TennisGame3 : ITennisGame
    {
        private int _playerTwoScore;
        private int _playerOneScore;
        private readonly string _playerOneName;
        private readonly string _playerTwoName;

        public TennisGame3(string player1Name, string player2Name)
        {
            _playerOneName = player1Name;
            _playerTwoName = player2Name;
        }

        public string GetScore()
        {
            string winningPlayerScoreText;
            
            if (_playerOneScore == _playerTwoScore && 
                _playerOneScore >= 3)
            {
                return "Deuce";
            }
            if (_playerOneScore < 4 && _playerTwoScore < 4)
            {
                string[] scoreConversions = { "Love", "Fifteen", "Thirty", "Forty" };
                winningPlayerScoreText = scoreConversions[_playerOneScore];
                if (_playerOneScore == _playerTwoScore)
                {
                    return winningPlayerScoreText + "-All";
                }

                var losingPlayerScoreText = scoreConversions[_playerTwoScore];
                return winningPlayerScoreText + "-" + losingPlayerScoreText;
            }

            winningPlayerScoreText = _playerOneScore > _playerTwoScore ? _playerOneName : _playerTwoName;
            if (Math.Abs(_playerOneScore - _playerTwoScore) == 1)
            {
                return "Advantage " + winningPlayerScoreText;
            }
            return "Win for " + winningPlayerScoreText;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
                _playerOneScore += 1;
            else
                _playerTwoScore += 1;
        }

    }
}