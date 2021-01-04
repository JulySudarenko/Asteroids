using UnityEngine;


namespace TheFifthLessonTasks.Bridge
{
    internal sealed class ExampleBridge : MonoBehaviour
    {
        private void Start()
        {
            var enemyMag = new Enemy(new MagicalAttack(), new Mag());
            var enemyInfantry = new Enemy(new InfantryAttack(), new Infantry());
            var enemyArcher = new Enemy(new ArcherAttack(), new Archer());
            
            enemyMag.Move();
            enemyArcher.Move();
            enemyInfantry.Move();
            
            enemyMag.Attack();
            enemyInfantry.Attack();
            enemyArcher.Attack();
        }
    }
}
