using UnityEngine;
using static Asteroids.NameManager;


namespace Asteroids
{
    public class SpaceshipFactory : ISpaceshipFactory
    {
        private readonly SpaceshipData _spaceshipData;
        private const float _mass = 1.0f;

        public SpaceshipFactory(SpaceshipData spaceshipData)
        {
            _spaceshipData = spaceshipData;
        }

        public GameObject CreateSpaceship()
        {
            return new GameObject(NAME_PLAYER)
                .AddTag(NAME_PLAYER)
                .AddTransform(_spaceshipData.SpaceshipTransform)
                .AddSprite(_spaceshipData.SpaceshipSprite)
                .AddRigidbody2D(_mass)
                .AddPoligonCollider2D();
        }
    }
}
