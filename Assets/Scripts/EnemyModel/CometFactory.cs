using UnityEngine;
using Object = UnityEngine.Object;


namespace Asteroids
{
    public class CometFactory : IEnemyFactory
    {
        public Enemy Create(Health hp)
        {
            var enemy =
                Object.Instantiate(Resources.Load<Comet>("Enemy/Comet"));

            enemy.Health = hp;
            return enemy;
        }
    }
}
