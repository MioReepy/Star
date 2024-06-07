using UnityEngine;

namespace AsteroidSpace
{
    public class AsteroidMove : MonoBehaviour
    {
        [SerializeField] private float _speedMin;
        [SerializeField] private float _speedMax;
        private int _speed;

        private void Start()
        {
            _speed = (int)Random.Range(_speedMin, _speedMax);
            GetComponent<Rigidbody>().velocity = transform.forward * -_speed;
        }
    }
}