using UnityEngine;


namespace Asteroids
{
    public interface IEnemyFactory
    {
        GameObject CreateEnemy();
    }
}
