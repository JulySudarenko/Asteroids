using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    internal interface IEnemyIterator
    {
        IAbility this[int index] { get; }
        string this[GraphicsBuffer.Target index] { get; }
        int MaxDamage { get; }
        IEnumerable<IAbility> GetAbility();
        IEnumerator GetEnumerator();
        IEnumerable<IAbility> GetAbility(DamageType index);
    }
}
