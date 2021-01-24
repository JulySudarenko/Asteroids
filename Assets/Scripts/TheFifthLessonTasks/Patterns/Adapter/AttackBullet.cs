using UnityEngine;


namespace TheFifthLessonTasks.Adapter
{
    internal sealed class AttackBullet : IAttack
    {
        public void Attack(UnityEngine.Vector3 position)
        {
            var bullet = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            bullet.name = "Bullet";
            bullet.transform.position = position;
        }
    }
}
