using UnityEngine;

namespace PlayerSpace
{
    public class Player : MonoBehaviour
    {
                
        [SerializeField] private float _speed;
        [SerializeField] private float _tilt;
        [SerializeField] PlayerBoundary _boundary;

        private Rigidbody _rigidbody;
        
        public static Player SimgltonPlayer;
        private PlayerController _playerController;
        private void Awake() => SimgltonPlayer = this;

        private void Start()
        {
            _playerController = GetComponent<PlayerController>();
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            Vector3 movement = new Vector3(_playerController.moveHorizontal, 0f, _playerController.moveVertical);

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