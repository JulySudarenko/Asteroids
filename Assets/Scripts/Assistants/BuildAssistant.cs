using UnityEngine;


namespace Asteroids
{
    public static class BuildAssistant
    {
        public static GameObject AddName(this GameObject gameObject, string name)
        {
            gameObject.name = name;
            return gameObject;
        }
        
        public static GameObject AddTag(this GameObject gameObject, string tag)
        {
            gameObject.tag = tag;
            return gameObject;
        }

        public static GameObject AddTransform(this GameObject gameObject, Transform transform)
        {
            gameObject.transform.position = transform.position;
            return gameObject;
        }

        public static GameObject AddRigidbody2D(this GameObject gameObject, float mass)
        {
            var component = GetOrAddComponent<Rigidbody2D>(gameObject);
            component.mass = mass;
            return gameObject;
        }

        public static GameObject AddPoligonCollider2D(this GameObject gameObject)
        {
            GetOrAddComponent<PolygonCollider2D>(gameObject);
            return gameObject;
        }
        
        public static GameObject AddCircleCollider2D(this GameObject gameObject)
        {
            GetOrAddComponent<CircleCollider2D>(gameObject);
            return gameObject;
        }

        public static GameObject AddSprite(this GameObject gameObject, Sprite sprite)
        {
            var component = gameObject.GetOrAddComponent<SpriteRenderer>();
            component.sprite = sprite;
            return gameObject;
        }

        private static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
        {
            var result = gameObject.GetComponent<T>();
            if (!result)
            {
                result = gameObject.AddComponent<T>();
            }

            return result;
        }
    }
}
