using UnityEngine;

namespace PlayerSpace
{
    public class BoltMove : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private void Start()
        {
            GetComponent<Rigidbody>().velocity = transform.forward * _speed;
        }
    }
}