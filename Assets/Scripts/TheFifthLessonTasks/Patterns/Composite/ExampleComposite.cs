using UnityEngine;


namespace TheFifthLessonTasks.Composite
{
    internal sealed class ExampleComposite : MonoBehaviour
    {
        private void Start()
        {
            IAttack attack = new Unit();
            Detachment attacks = new Detachment();
            attacks.AddUnit(attack);
            attack.Attack();
            attacks.Attack();
            attacks.RemoveUnit(attack);
        }
    }
}
