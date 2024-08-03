using UnityEngine;
using InviromentSpace;
using WeaponSpace;

namespace PlayerSpace
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _tilt;
        [SerializeField] PlayerBoundary _boundary;
        
        private Rigidbody _rigidbody;

        static public Player SingletonPlayer;
        
        private void Awake() => SingletonPlayer = this;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        internal void Move(Vector2 input)
        {
            _rigidbody.velocity = new Vector3(input.x, 0f, input.y) * _speed;
            _rigidbody.rotation = Quaternion.Euler(0f, 0f, _rigidbody.velocity.x * -_tilt);
            _rigidbody.position = new Vector3
            (
                Mathf.Clamp(_rigidbody.position.x, _boundary._xMin, _boundary._xMax),
                0f,
                Mathf.Clamp(_rigidbody.position.z, _boundary._zMin, _boundary._zMax)
            );
        }

        public void Shoot()
        {
            Bolt._isPoof = true;
        }
    }
}