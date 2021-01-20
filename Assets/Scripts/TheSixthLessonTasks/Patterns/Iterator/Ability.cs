using UnityEngine;

namespace TheSixthLessonTasks.Patterns.Iterator
{
    internal sealed class Ability : IAbility
    {
        public string Name { get; }
        public int Damage { get; }
        public GraphicsBuffer.Target Target { get; }
        public DamageType DamageType { get; }

        public Ability(string name, int damage, GraphicsBuffer.Target target, DamageType
            damageType)
        {
            Name = name;
            Target = target;
            DamageType = damageType;
            Damage = damage;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
