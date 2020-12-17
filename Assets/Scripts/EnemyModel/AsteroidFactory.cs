using UnityEngine;
using Object = UnityEngine.Object;


namespace Asteroids
{
    public sealed class AsteroidFactory : IEnemyFactory
    {
        public Enemy Create(Health hp)
        {
            var enemy =
                Object.Instantiate(Resources.Load<Asteroid>("Enemy/Asteroid"));

            enemy.Health = hp;
            return enemy;
        }
    }
}
