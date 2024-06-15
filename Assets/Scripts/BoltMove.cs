using UnityEngine;

namespace PlayerSpace
{
    public class BoltMove : MonoBehaviour
    {
        [SerializeField] private float _speed;
        private Rigidbody _rigidbody;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            _rigidbody.velocity = transform.forward * _speed;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Asteroid")
            {
                Generator.ReturnAsteroidOrEnemyToPool(other.gameObject);
                Pool.ReturnBoltToPool(gameObject);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.tag == "Boundary")
            {
                Pool.ReturnBoltToPool(gameObject);
            }
        }
    }
}