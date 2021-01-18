using System;
using System.Collections.Generic;
using UnityEngine;
using static Asteroids.NameManager;


namespace Asteroids
{
    public class ContactObjectsCenter : IContactCenter
    {
        private readonly Dictionary<int, GameObject> _contactInfo;
        public Dictionary<int, GameObject> ContactInfo => _contactInfo;

        public ContactObjectsCenter()
        {
            _contactInfo = new Dictionary<int, GameObject>();
        }
  
        public void AddContactInfo(GameObject gameObject)
        {
            Debug.Log($"{gameObject.GetInstanceID()} {gameObject} add to list");
            _contactInfo.Add(gameObject.GetInstanceID(), gameObject);
        }
    }
}
