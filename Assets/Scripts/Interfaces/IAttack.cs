using UnityEngine;

namespace Asteroids
{
    public interface IAttack
    {
        void Shoot(Transform shotPoint);
    }
}
