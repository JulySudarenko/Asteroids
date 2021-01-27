using System;
using System.Collections.Generic;
using UnityEngine;
using static Asteroids.NameManager;

namespace Asteroids
{
    public class ContactCenter : ICleanup
    {
        public Action<string> TransferPointsOnScreen;
        public Action<Transform> BulletHit;
        public Action<Transform> EnemyHit;
        public Action<float> SpaceshipHit;

        private readonly Dictionary<int, GameObject> _contactInfo;
        private readonly List<TrackingContacts> _contacts;

        private readonly ScoreInterpreter _scoreInterpreter;
        private readonly SpecifySpaceshipDamage _specifySpaceshipDamage;

        public ContactCenter(EnemyData points, Data power)
        {
            _scoreInterpreter = new ScoreInterpreter(points);
            _specifySpaceshipDamage = new SpecifySpaceshipDamage(power);
            _contactInfo = new Dictionary<int, GameObject>();
            _contacts = new List<TrackingContacts>();
        }


        public void AddContactInfo(GameObject gameObject)
        {
            _contactInfo.Add(gameObject.GetInstanceID(), gameObject);
            var contact = gameObject.GetOrAddComponent<TrackingContacts>();
            _contacts.Add(contact);
            contact.CollisionHappend += IdentifyCollisionInfo;
        }

        public void IdentifyCollisionInfo(int gameObjectID, int collisionObjectID)
        {
            if (_contactInfo.ContainsKey(gameObjectID) && _contactInfo.ContainsKey(collisionObjectID))
            {
                ReallocateCollisionInfo(_contactInfo[gameObjectID], _contactInfo[collisionObjectID].name);
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(collisionObjectID), collisionObjectID,
                    "Unidentified contact.");
            }
        }

        private void ReallocateCollisionInfo(GameObject gameObject, string name)
        {
            switch (gameObject.name)
            {
                case NAME_ASTEROID:
                    if (name == NAME_AMMUNITION)
                        EnemyHit?.Invoke(gameObject.transform);
                    break;
                case NAME_COMET:
                    if (name == NAME_AMMUNITION)
                        EnemyHit?.Invoke(gameObject.transform);
                    break;
                case NAME_HUNTER:
                    if (name == NAME_AMMUNITION | name == NAME_PLAYER)
                        EnemyHit?.Invoke(gameObject.transform);
                    break;
                case NAME_PLAYER:
                    var damage = _specifySpaceshipDamage.MakeDamageDecision(name);
                    SpaceshipHit?.Invoke(damage);
                    break;
                case NAME_AMMUNITION:
                    BulletHit?.Invoke(gameObject.transform);
                    var score = _scoreInterpreter.CountGamePoints(name);
                    TransferPointsOnScreen?.Invoke(score);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(name), name,
                        "Attention!!! Unidentified flying object detected");
            }
        }

        public void Cleanup()
        {
            foreach (var contact in _contacts)
            {
                contact.CollisionHappend -= IdentifyCollisionInfo;
            }
        }
    }
}
