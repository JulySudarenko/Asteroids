using System;

namespace Asteroids
{
    public class ScoreInterpreter
    {
        private IPoints _asteroidPoints;
        private IPoints _cometPoints;
        private IPoints _hunterPoints;
        private float _gameScore = 0.0f;

        public ScoreInterpreter(EnemyData points)
        {
            _asteroidPoints = points.AsteroidData;
            _cometPoints = points.CometData;
            _hunterPoints = points.HunterData;
        }

        public string CountGamePoints(string name)
        {
            var points = MakePointsDecision(name);
            _gameScore += points;
            string line = Interpreter.Rewrite(_gameScore);
            return line;
        }

        private float MakePointsDecision(string name)
        {
            switch (name)
            {
                case NameManager.NAME_ASTEROID:
                    return _asteroidPoints.Points;
                case NameManager.NAME_COMET:
                    return _cometPoints.Points;
                case NameManager.NAME_HUNTER:
                    return _hunterPoints.Points;
                case NameManager.NAME_AMMUNITION:
                    return 0.0f;
                case NameManager.NAME_PLAYER:
                    return 0.0f;
                default:
                    throw new ArgumentOutOfRangeException(nameof(name), name,
                        "Can't change game score.");
            }
        }
    }
}
