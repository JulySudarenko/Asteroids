using System;
using UnityEngine;
using static Asteroids.NameManager;


namespace Asteroids
{
    public class CollisionInfo
    {
        //public event Action<Transform, Collider2D> CollisionHappend;

        // public CollisionInfo()
        // {
        //     CollisionHappend = SendCollisionMessage;
        // }
        // private const string ASTEROID = "Asteroid";
        // private const string FIRSTAID = "FirstAid";
        // private HealthKeeper _healthKeeper;
        // private float _damagePoints = 2.0f; // взять у астероида
        // private float _healPoints = 5.0f; //взять у аптечки
        //
        // public TrackingSpaceshipContacts(HealthKeeper healthKeeper)
        // {
        //     _healthKeeper = healthKeeper;
        // }

        private void SendCollisionMessage(Transform gameObject, Collider2D collider)
        {
            // if (gameObject.name is NAME_PLAYER)
            // {
            //     _healthKeeper.DamageDone?.Invoke(_damagePoints);
            // }
            //
            // if (other.collider.CompareTag(FIRSTAID))
            // {
            //     _healthKeeper.FirstAidReceived?.Invoke(_healPoints);
            // }
        }
    }
}
