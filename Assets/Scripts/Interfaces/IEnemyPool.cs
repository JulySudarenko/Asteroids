﻿using UnityEngine;

namespace Asteroids
{
    public interface IEnemyPool
    {
        Rigidbody2D GetEnemy(string type);
    }
}
