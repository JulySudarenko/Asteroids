using UnityEngine;

namespace Asteroids
{
    internal interface IAbility
    {
        string Name { get; }
        int Damage { get; }
        GraphicsBuffer.Target Target { get; }
        DamageType DamageType { get; }
    }
}
