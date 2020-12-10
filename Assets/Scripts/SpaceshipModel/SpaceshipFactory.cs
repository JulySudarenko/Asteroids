using UnityEngine;


namespace Asteroids
{
    public class SpaceshipFactory : ISpaceshipFactory
    {
        private readonly SpaceshipData _spaceshipData;
        private string _name = "Player";

        public SpaceshipFactory(SpaceshipData spaceshipData)
        {
            _spaceshipData = spaceshipData;
        }

        public GameObject CreateSpaceship()
        {
            return new GameObject(_name)
                .AddTag(_name)
                .AddTransform(_spaceshipData.SpaceshipTransform)
                .AddSprite(_spaceshipData.SpaceshipSprite)
                .AddPoligonCollider2D();
        }
    }
}
