using UnityEngine;

namespace TheFifthLessonTasks.Bridge
{
    internal sealed class MagicalAttack : IAttack
    {
        public void Attack()
        {
            Debug.Log("Magical attack");
        }
    }
}
