using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TheSixthLessonTasks.Patterns.Iterator
{
    internal sealed class ExampleIterator : MonoBehaviour
    {
        private void Start()
        {
            var ability = new List<IAbility>
            {
                new Ability("Inner Fire", 100, (GraphicsBuffer.Target) Target.None,
                    DamageType.Magical),
                new Ability("Burning Spear", 200, (GraphicsBuffer.Target) (Target.Unit | Target.Autocast), DamageType.Magical),
                new Ability("Berserker's Blood", 300, (GraphicsBuffer.Target) Target.Passive,
                    DamageType.None),
                new Ability("Life Break", 400, (GraphicsBuffer.Target) Target.Unit,
                    DamageType.Magical),
            };
            IEnemy enemy = new Enemy(ability);

            Debug.Log(enemy[0]);
            Debug.Log(new string('+', 50));
            Debug.Log(enemy[(GraphicsBuffer.Target) (Target.Unit | Target.Autocast)]);
            Debug.Log(new string('+', 50));
            Debug.Log(enemy[(GraphicsBuffer.Target) (Target.Unit | Target.Passive)]);
            Debug.Log(new string('+', 50));
            Debug.Log(enemy.MaxDamage);
            Debug.Log(new string('+', 50));
            foreach (var o in enemy)
            {
                Debug.Log(o);
            }

            Debug.Log(new string('+', 50));
            foreach (var o in enemy.GetAbility().Take(2))
            {
                Debug.Log(o);
            }

            Debug.Log(new string('+', 50));
            foreach (var o in enemy.GetAbility(DamageType.Magical))
            {
                Debug.Log(o);
            }
        }
        
    }
}
