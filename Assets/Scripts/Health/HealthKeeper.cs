using System;
using UnityEngine;


namespace Asteroids
{
    public class HealthKeeper
    {
        private IHealth _maxHealth;
        private float _spaceshipHealth;

        public float SpaceshipHealth => _spaceshipHealth;

        public HealthKeeper(IHealth maxHealth)
        {
            _maxHealth = maxHealth;
            _spaceshipHealth = _maxHealth.Health;
        }

        public void DetermineContact(GameObject gameObject)
        {
            switch (gameObject.name)
            {
                case NameManager.NAME_ASTEROID + "(Clone)":
                    CauseDamage(10.0f);
                    Debug.Log(_spaceshipHealth);
                    break;
                case NameManager.NAME_COMET + "(Clone)":
                    CauseDamage(5.0f);
                    Debug.Log(_spaceshipHealth);
                    break;
                case NameManager.NAME_HUNTER:
                    CauseDamage(7.0f);
                    Debug.Log(_spaceshipHealth);
                    break;
                case NameManager.NAME_AMMUNITION:
                    Debug.Log(_spaceshipHealth);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(gameObject), gameObject,
                        "Не предусмотрен в программе");
            }
        }

        private void CauseDamage(float point)
        {
            _spaceshipHealth -= point;
            if (_spaceshipHealth <= 0)
            {
                Destroy();
            }
        }

        private void Heal(float point)
        {
            _spaceshipHealth += point;
            if (_spaceshipHealth >= _maxHealth.Health)
            {
                _spaceshipHealth = _maxHealth.Health;
            }
        }

        private void Destroy()
        {
            Debug.Log("Player is dead");
        }
    }
}
