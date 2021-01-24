using UnityEngine;

namespace Asteroids
{
    public class MainController : MonoBehaviour
    {
        [SerializeField] private Data _data;
        private Facade _facade;


        private void Awake()
        {
            _facade = new Facade(_data);
            _facade.FacadeInitialize();
        }

        private void FixedUpdate()
        {
            _facade.FacadeFixedExecute(Time.deltaTime);
        }

        private void Update()
        {
            _facade.FacadeExecute(Time.deltaTime);
        }

        private void OnDestroy()
        {
            _facade.FacadeCleanup();
        }
    }
}
