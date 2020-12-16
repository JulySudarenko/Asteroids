using System;
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
            if (enemy is null)
            {
                throw new NullReferenceException("Check comet!");
            }

            enemy.Health = hp;
            return enemy;
        }
    }
}
