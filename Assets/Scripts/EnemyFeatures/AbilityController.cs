using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Asteroids
{
    internal class AbilityController
    {
        private IEnemyIterator _huntersAbility;

        public void AbilityDemonstration()
        {
            CreateListAbilities();
            ShowAbility();
        }
        
        private void CreateListAbilities()
        {
            List<IAbility> ability = new List<IAbility>
            {
                new Ability("Inner Fire", 10, (GraphicsBuffer.Target) Target.None,
                    DamageType.Magical),
                new Ability("Burning Spear", 20, (GraphicsBuffer.Target) (Target.Unit | Target.Autocast),
                    DamageType.Magical),
                new Ability("Berserker's Blood", 30, (GraphicsBuffer.Target) Target.Passive,
                    DamageType.None),
                new Ability("Life Break", 40, (GraphicsBuffer.Target) Target.Unit,
                    DamageType.Magical),
            };

            _huntersAbility = new EnemtAbility(ability);
        }

        private void ShowAbility()
        {
            Debug.Log(_huntersAbility[0]);
            Debug.Log(new string('+', 50));
            Debug.Log(_huntersAbility[(GraphicsBuffer.Target) (Target.Unit | Target.Autocast)]);
            Debug.Log(new string('+', 50));
            Debug.Log(_huntersAbility[(GraphicsBuffer.Target) (Target.Unit | Target.Passive)]);
            Debug.Log(new string('+', 50));
            Debug.Log(_huntersAbility.MaxDamage);
            Debug.Log(new string('+', 50));
            foreach (var o in _huntersAbility)
            {
                Debug.Log(o);
            }

            Debug.Log(new string('+', 50));
            foreach (var o in _huntersAbility.GetAbility().Take(2))
            {
                Debug.Log(o);
            }

            Debug.Log(new string('+', 50));
            foreach (var o in _huntersAbility.GetAbility(DamageType.Magical))
            {
                Debug.Log(o);
            }
        }

    }
}
