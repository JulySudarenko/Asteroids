using UnityEngine;


namespace Asteroids
{
    public class TrackingSpaceshipContacts : MonoBehaviour
    {
        private const string ASTEROID = "Asteroid";
        private const string FIRSTAID = "FirstAid";
        private HealthKeeper _healthKeeper;
        private float _damagePoints = 2.0f; // взять у астероида
        private float _healPoints = 5.0f; //взять у аптечки

        public TrackingSpaceshipContacts(HealthKeeper healthKeeper)
        {
            _healthKeeper = healthKeeper;
        }
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            Debug.Log("Contact");
            if (other.collider.CompareTag(ASTEROID))
            {
                _healthKeeper.DamageDone?.Invoke(_damagePoints);
            }

            if (other.collider.CompareTag(FIRSTAID))
            {
                _healthKeeper.FirstAidReceived?.Invoke(_healPoints);
            }
        }
    }
}
