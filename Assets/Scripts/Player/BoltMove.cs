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
    }
}