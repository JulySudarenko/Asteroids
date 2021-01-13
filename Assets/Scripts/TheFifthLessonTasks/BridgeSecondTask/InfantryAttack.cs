using UnityEngine;

namespace TheFifthLessonTasks.Bridge
{
    public sealed class InfantryAttack : IAttack
    {
        public void Attack()
        {
            Debug.Log("Infantry attack");
        }
    }
}
