using UnityEngine;


namespace TheFifthLessonTasks.Bridge
{
    public sealed class ArcherAttack : IAttack
    {
        public void Attack()
        {
            Debug.Log("Archer attack");
        }
    }
}
