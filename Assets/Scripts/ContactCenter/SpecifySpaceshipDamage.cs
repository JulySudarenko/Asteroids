using System;

namespace Asteroids
{
    public class SpecifySpaceshipDamage
    {
        private IPower _asteroidPower;
        private IPower _cometPower;
        private IPower _hunterPower;

        public SpecifySpaceshipDamage(Data power)
        {
            _asteroidPower = power.EnemyData.AsteroidData;
            _cometPower = power.EnemyData.CometData;
            _hunterPower = power.EnemyData.HunterData;
        }

        public float MakeDamageDecision(string name)
        {
            switch (name)
            {
                case NameManager.NAME_ASTEROID:
                    return _asteroidPower.Power;
                case NameManager.NAME_COMET:
                    return _cometPower.Power;
                case NameManager.NAME_HUNTER:
                    return _hunterPower.Power;
                case NameManager.NAME_AMMUNITION:
                    return 0.0f;
                case NameManager.NAME_PLAYER:
                    return 0.0f;
                default:
                    throw new ArgumentOutOfRangeException(nameof(name), name,
                        "Can't damage the spaceship.");
            }
        }
    }
}
