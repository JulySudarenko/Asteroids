using System;
using System.Collections.Generic;
using UnityEngine;
using static Asteroids.Interpreter;
using static Asteroids.NameManager;


namespace Asteroids
{
    public class ContactCenter
    {
        public Action<string> TransferPointsOnScreen;
        public Action<Transform> BulletHit;

        private readonly Dictionary<int, GameObject> _contactInfo;
        private readonly ScoreInterpreter _scoreInterpreter;
        private readonly EnemyContact _enemyContact;
        private readonly SpaceshipContact _spaceshipContact;


        private IPower _power;
        private IPoints _points;
        private float _gameScore = 0.0f;

        public ContactCenter(EnemyData points, Data power)
        {
            _scoreInterpreter = new ScoreInterpreter(points);
            _contactInfo = new Dictionary<int, GameObject>();
            _points = points.AsteroidData;
            _power = power.EnemyData.AsteroidData;
        }


        public Dictionary<int, GameObject> ContactInfo => _contactInfo;

        public void AddContactInfo(GameObject gameObject)
        {
            Debug.Log($"{gameObject.GetInstanceID()} {gameObject} add to list");
            _contactInfo.Add(gameObject.GetInstanceID(), gameObject);
            var contact = gameObject.GetOrAddComponent<TrackingContacts>();
            contact.CollisionHappend += IdentifyCollisionInfo;
        }

        public void IdentifyCollisionInfo(int gameObjectID, int collisionObjectID)
        {
            if (_contactInfo.ContainsKey(gameObjectID) && _contactInfo.ContainsKey(collisionObjectID))
            {
                Debug.Log($"{gameObjectID} contact {collisionObjectID}");
                ReallocateCollisionInfo(_contactInfo[gameObjectID], _contactInfo[collisionObjectID]);
            }

            else
            {
                Debug.Log("Unidentified contact.");
            }
        }

        private void ReallocateCollisionInfo(GameObject gameObject, GameObject collisionObject)
        {
            switch (gameObject.name)
            {
                case NAME_ASTEROID:
                    Debug.Log($"{gameObject.name} was identified");
                    //CountGamePoints(_points.Points);
                    break;
                case NAME_COMET:
                    Debug.Log($"{gameObject.name} was identified");
                    break;
                case NAME_HUNTER:
                    Debug.Log($"{gameObject.name} was identified");
                    break;
                case NAME_PLAYER:
                    Debug.Log($"{gameObject.name} was identified");
                    break;
                case NAME_AMMUNITION:
                    Debug.Log($"{gameObject.name} was identified");
                    BulletHit?.Invoke(gameObject.transform);
                    var score = _scoreInterpreter.CountGamePoints(collisionObject.name);
                    TransferPointsOnScreen?.Invoke(score);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(collisionObject), collisionObject.name,
                        "Attention!!! Unidentified flying object detected");
            }
        }
    }

    public class EnemyContact
    {
        private float _spaceshipPower;
        private float _bulletPower;
    }

    public class SpaceshipContact
    {
        private float _asteroidPower;
        private float _cometPower;
        private float _hunterPower;
    }

    public class ScoreInterpreter
    {
        private IPoints _asteroidPoints;
        private IPoints _cometPoints;
        private IPoints _hunterPoints;
        private float _gameScore = 0.0f;

        public ScoreInterpreter(EnemyData points)
        {
            _asteroidPoints = points.AsteroidData;
            _cometPoints = points.CometData;
            _hunterPoints = points.HunterData;
        }

        public string CountGamePoints(string name)
        {
            var points = MakePointsDecision(name);
            _gameScore += points;
            string line = Rewrite(_gameScore);
            return line;
        }

        private float MakePointsDecision(string name)
        {
            switch (name)
            {
                case NAME_ASTEROID:
                    return _asteroidPoints.Points;
                case NAME_COMET:
                    return _cometPoints.Points;
                case NAME_HUNTER:
                    return _hunterPoints.Points;
                case NAME_AMMUNITION:
                    return 0.0f;
                case NAME_PLAYER:
                    return 0.0f;
                default:
                    throw new ArgumentOutOfRangeException(nameof(name), name,
                        "Can't change game score.");
            }
        }
    }
}
