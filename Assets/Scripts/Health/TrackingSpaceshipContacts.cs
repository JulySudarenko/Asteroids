﻿using System;
using UnityEngine;


namespace Asteroids
{
    public class TrackingSpaceshipContacts : MonoBehaviour
    {
        public event Action<GameObject> SpaceshipCollisionHappend;

        private void OnCollisionEnter2D(Collision2D other)
        {
            Debug.Log($"Spaceship contact {other.collider.gameObject}");
            SpaceshipCollisionHappend?.Invoke(other.collider.gameObject);
        }
    }
}
