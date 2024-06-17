using UnityEngine;
using WeaponSpace;

namespace InviromentSpace
{
    public class DestroyByContact : MonoBehaviour
    {
        [SerializeField] private GameObject _explosion;
        [SerializeField] private GameObject _playerExplotion;
        [SerializeField] private float _workTimer = 1f;

        private float _timer;
        
        public delegate void Kill();
        public static event Kill OnKill;

        private void OnTriggerEnter(Collider other)
        {
            _timer = 0;
            
            if (other.tag == "Boundary" || (other.tag == "Enemy" && gameObject.tag == "EnemyBolt") || (other.tag == "EnemyBolt" && gameObject.tag == "Enemy") )
            {
                return;
            }

            if (_explosion != null && (other.tag == "Asteroid" || other.tag == "Enemy"))
            {
                Explosion(other.gameObject, _explosion);
            }

            if (_explosion != null && (other.tag == "EnemyBolt" || other.tag == "PlayerBolt"))
            {
                Explosion(other.gameObject, _explosion);
            }
            
            if (_playerExplotion != null && other.tag == "Player")
            {
                Explosion(other.gameObject, _playerExplotion);
                OnKill?.Invoke();
            }
        }

        private void Explosion(GameObject other, GameObject explosion)
        {
            _timer += Time.deltaTime;
            GameObject explosionBlust = Instantiate(explosion, other.transform.position, other.transform.rotation);

            if (other.tag == "EnemyBolt")
            {
                EnemyWeapon.ReturnBoltToPool(other);
            }
            else if (other.tag == "PlayerBolt")
            {
                Bolt.ReturnBoltToPool(other);
            }
            else if (other.tag == "Asteroid" || other.tag == "Enemy")
            {
                Generator.ReturnAsteroidOrEnemyToPool(other);
            }
            else
            {
                return;
            }
            
            if (_timer >= _workTimer)
            {
                Destroy(explosionBlust);
            }

            _timer = 0;
        }
    }
}
