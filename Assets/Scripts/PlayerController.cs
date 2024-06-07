using System;
using UnityEngine;

namespace PlayerSpace
{
    [Serializable]
    public class Boundary
    {
        public float _xMin, _xMax, _zMin, _zMax; 
    }

    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _tilt;
        [SerializeField] Boundary _boundary;

        private Rigidbody _rigidbody;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);

            _rigidbody.velocity = movement * _speed;
            _rigidbody.rotation = Quaternion.Euler(0f, 0f, _rigidbody.velocity.x * -_tilt);
            _rigidbody.position = new Vector3
            (
                Mathf.Clamp(_rigidbody.position.x, _boundary._xMin, _boundary._xMax),
                0f,
                Mathf.Clamp(_rigidbody.position.z, _boundary._zMin, _boundary._zMax)
            );
        }
    }
}
