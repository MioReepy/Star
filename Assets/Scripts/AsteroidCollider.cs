using UnityEngine;

namespace AsteroidSpace
{
    public class AsteroidCollider : MonoBehaviour
    {
        public delegate void Kill();
        public static event Kill OnKill;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                OnKill?.Invoke();
            }
        }
    }
}