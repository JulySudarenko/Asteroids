using System;
using System.Collections.Generic;
using UnityEngine;
using static Asteroids.NameManager;


namespace Asteroids
{
    public class ContactObjectsCenter : IContactCenter
    {
        private readonly Dictionary<int, GameObject> _contactInfo;

        public ContactObjectsCenter()
        {
            _contactInfo = new Dictionary<int, GameObject>();
        }

        public Dictionary<int, GameObject> ContactInfo => _contactInfo;

        public void AddContactInfo(GameObject gameObject)
        {
            Debug.Log($"{gameObject.GetInstanceID()} {gameObject} add to list");
            _contactInfo.Add(gameObject.GetInstanceID(), gameObject);
        }

        private void ReallocateCollisionInfo(GameObject gameObject, GameObject collisionObject)
        {
            switch (collisionObject.name)
            {
                case NAME_ASTEROID:
                    Debug.Log($"{gameObject.name} faced with {collisionObject}");
                    break;
                case NAME_COMET:
                    Debug.Log($"{gameObject.name} faced with {collisionObject}");
                    break;
                case NAME_HUNTER:
                    Debug.Log($"{gameObject.name} faced with {collisionObject}");
                    break;
                case NAME_PLAYER:
                    Debug.Log($"{gameObject.name} faced with {collisionObject}");
                    break;
                case NAME_AMMUNITION:
                    Debug.Log($"{gameObject.name} faced with {collisionObject}");
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(gameObject.name), gameObject.name,
                        "Attention!!! Unidentified flying object detected");
            }
        }
    }
}
