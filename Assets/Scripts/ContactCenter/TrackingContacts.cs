using System;
using UnityEngine;


namespace Asteroids
{
    public class TrackingContacts : MonoBehaviour
    {
        public event Action<int, int> CollisionHappend;

        private void OnCollisionEnter2D(Collision2D other)
        {
            CollisionHappend?.Invoke(gameObject.GetInstanceID(), other.collider.gameObject.GetInstanceID());
        }
    }
}
