using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheSixthLessonTasks.Patterns.Iterator
{
    internal interface IEnemy
    {
        IAbility this[int index] { get; }
        string this[GraphicsBuffer.Target index] { get; }
        int MaxDamage { get; }
        IEnumerable<IAbility> GetAbility();
        IEnumerator GetEnumerator();
        IEnumerable<IAbility> GetAbility(DamageType index);
    }
}
