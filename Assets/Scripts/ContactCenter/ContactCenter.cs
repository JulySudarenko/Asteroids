using System;
using System.Collections.Generic;
using UnityEngine;
using static Asteroids.NameManager;

namespace Asteroids
{
    public class ContactCenter : IIinitialize, ICleanup
    {
        public Action<string> TransferPointsOnScreen;
        public Action<Transform> BulletHit;
        public Action<Transform> EnemyHit;
        public Action<float> SpaceshipHit;

        private readonly Dictionary<int, GameObject> _contactInfo;

        private MessageBroker _messageBroker;
        private readonly ScoreInterpreter _scoreInterpreter;
        private readonly SpecifySpaceshipDamage _specifySpaceshipDamage;

        public ContactCenter(EnemyData points, Data power, MessageBroker messageBroker)
        {
            _messageBroker = messageBroker;
            _scoreInterpreter = new ScoreInterpreter(points);
            _specifySpaceshipDamage = new SpecifySpaceshipDamage(power);
            _contactInfo = new Dictionary<int, GameObject>();
        }

        public void Initialize()
        {
            EnemyHit += _messageBroker.AddMessage;
        }

        public Dictionary<int, GameObject> ContactInfo => _contactInfo;

        public void AddContactInfo(GameObject gameObject)
        {
            _contactInfo.Add(gameObject.GetInstanceID(), gameObject);
            var contact = gameObject.GetOrAddComponent<TrackingContacts>();
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
                    EnemyHit?.Invoke(gameObject.transform);
                    break;
                case NAME_COMET:
                    EnemyHit?.Invoke(gameObject.transform);
                    break;
                case NAME_HUNTER:
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
            EnemyHit -= _messageBroker.AddMessage;
        }
    }
}
