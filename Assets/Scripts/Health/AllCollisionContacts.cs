using System;
using UnityEngine;


namespace Asteroids
{
    public class AllCollisionContacts
    {
        public Action<float> TransferDamageInfo;
        private IContactCenter _contactCenter;


        public void DetermineContact(GameObject gameObject)
        {
            Debug.Log(_contactCenter.ContactInfo.Count);
        }
    }
}
